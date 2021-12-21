using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Metering.Services;

namespace Metering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccounts : ControllerBase
    {
        private readonly ICustomerAccountsService _service;
         public CustomerAccounts(ICustomerAccountsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all customer accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var _items = _service.GetAllAccounts();
            return Ok(_items);
        }

        /// <summary>
        ///  Get customer account by id
        /// </summary>
        /// <param name="id"> Id of the account </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            var _item = _service.GetAccountById(id);
            if (_item == null)
            {
                return NotFound();
            }
            return Ok(_item);

        }

        /// <summary>
        /// Create Customer account
        /// </summary>
        /// <param name="value">account details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Model.Accounts value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.AddAccount(value);
            return CreatedAtAction("Get", new { id = item.AccountId }, item);
        }

        /// <summary>
        /// Remove Customer account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var _item = _service.GetAccountById(id);
            if (_item == null)
            {
                return NotFound();
            }
            _service.RemoveAccount(id);
            return NoContent();
        }
    }
}
