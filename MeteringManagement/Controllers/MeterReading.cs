using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Metering.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Globalization;
using CsvHelper;
using LinqToDB;

namespace Metering.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReading : ControllerBase
    {
        private readonly ILogger<MeterReading> _logger;
        private readonly DBConnection connection;

        public MeterReading(ILogger<MeterReading> logger,
                            DBConnection _conn)
        {
            _logger = logger;
            connection = _conn;
        }

       
        [HttpPost]
        [Route("/meter-reading-uploads")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                if (Directory.Exists("app_data") == false)
                {
                    Directory.CreateDirectory("app_data");
                }
                var _path = Path.Combine(Directory.GetCurrentDirectory(), "app_data", file.FileName);
                using (var stream = new FileStream(_path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(Validation(_path));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        private Result Validation(string path)
        {
            try
            {
                using (StreamReader _reader = new StreamReader(path))
                
                using (var csv = new CsvReader(_reader, CultureInfo.InvariantCulture))
                {
                    var recs = csv.GetRecords<Model.MeterReading>().ToList();
                    var accounts = connection.dboAccount.Select(x => x.AccountId).ToList();
                    int _failed = 0;
                    int _success = 0;
                    
                    Regex r = new Regex(@"^\d{5}$"); //Regular expression to validate meter reading

                    Dictionary<int, Model.MeterReading> _entries = new Dictionary<int, Model.MeterReading>();
                    List<Model.MeterReading> failedEntry = new List<Model.MeterReading>();

                    for (int i = 0; i < recs.Count(); i++)
                    {
                        if (accounts.Contains(recs[i].AccountId) == false)
                        {
                            _failed++;
                            failedEntry.Add(recs[i]);
                            continue;
                        }
                        if (_entries.ContainsKey(recs[i].AccountId))
                        {
                            _failed++;
                            failedEntry.Add(recs[i]);
                            continue;
                        }
                        //third check:
                        if (r.Match(recs[i].MeterReadValue).Success)
                        {
                            //Add to db
                            _success++;
                            _entries.Add(recs[i].AccountId, recs[i]);

                            if (SaveResults(recs[i]))
                            {
                                //Do we mark already saved entry as failure or update?
                            }
                        }
                        else
                        {
                            _failed++;
                            failedEntry.Add(recs[i]);
                        }
                    }
                    var passed = _entries.Select(x => x.Value).Select(x => new
                    MeterReadingResult
                    {
                        AccountId = x.AccountId,
                        MeterReadingDateTime = x.MeterReadingDateTime,
                        MeterReadValue = x.MeterReadValue,
                        Result = "Passed"
                    }).ToList();
                    var failedList = failedEntry.Select(x => new
                    MeterReadingResult
                    {
                        AccountId = x.AccountId,
                        MeterReadingDateTime = x.MeterReadingDateTime,
                        MeterReadValue = x.MeterReadValue,
                        Result = "Failed"
                    }).ToList();
                    passed.AddRange(failedList);

                    return new Result
                    {
                        Failures = _failed,
                        Successes = _success,
                        rows = passed
                    };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private bool SaveResults(Model.MeterReading reading)
        {
            int n =connection.InsertOrReplace(reading);
            return n > 0;
        }
    }
}
