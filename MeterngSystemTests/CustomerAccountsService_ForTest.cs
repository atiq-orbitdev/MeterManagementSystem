using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metering.Services;
using Metering.Model;
using Microsoft.AspNetCore.Mvc;
namespace MeterngSystemTests
{
    public class CustomerAccountService_ForTest : ICustomerAccountsService
    {
        private readonly List<Accounts> _customerAccounts;

        public CustomerAccountService_ForTest()
        {
            _customerAccounts = new List<Accounts>()
            {
                new Accounts() { AccountId =1001,
                    FirstName = "Jeremy", LastName="Sheirs" },
                new Accounts() { AccountId = 1002,
                    FirstName = "Justin", LastName="Downes" }
            };
        }

        public IEnumerable<Accounts> GetAllAccounts()
        {
            return _customerAccounts;
        }

        public Accounts AddAccount(Accounts newItem)
        {
            newItem.AccountId = 4;
            _customerAccounts.Add(newItem);
            return newItem;
        }

        public Accounts GetAccountById(int id)
        {
            return _customerAccounts.Where(a => a.AccountId == id)
                .FirstOrDefault();
        }

        public void RemoveAccount(int id)
        {
            var existing = _customerAccounts.First(a => a.AccountId == id);
            _customerAccounts.Remove(existing);
        }
    }
}
