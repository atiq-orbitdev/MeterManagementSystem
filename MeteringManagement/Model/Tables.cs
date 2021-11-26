using System.Data;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System;
using LinqToDB.Extensions;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.Configuration;
using LinqToDB;

namespace Metering.Model
{
    public class Result
    {
        public int Successes { get; set; }
        public int Failures { get; set; }
        public List<MeterReadingResult> rows { get; set; }
    }
    [Table]
    public class Accounts
    {
        [Column, PrimaryKey, NotNull] public int AccountId { get; set; }
        [Column, NotNull] public string FirstName { get; set; }
        [Column, NotNull] public string LastName { get; set; }
    }

#nullable enable

    [Table]
    public class MeterReading
    {
        [Column, PrimaryKey, NotNull] public int AccountId { get; set; }
        [Column, PrimaryKey, NotNull] public string MeterReadingDateTime { get; set; }
        [Column, Nullable] public string? MeterReadValue { get; set; }
    }
    public class MeterReadingResult : MeterReading
    {
        public string Result { get; set; }
    }
#nullable restore

    public class DBConnection : DataConnection
    {
        public DBConnection(LinqToDbConnectionOptions<DBConnection> options) : base(options)
        {
        }

        public ITable<Accounts> dboAccount => GetTable<Model.Accounts>();//GetTable<Model.Accounts>();
        public ITable<MeterReading> dboReading => GetTable<Model.MeterReading>();
    }
}
