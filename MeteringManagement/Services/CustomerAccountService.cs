using System;
using System.Collections.Generic;
using System.Linq;
using Metering.Model;
using Microsoft.Extensions.Logging;

namespace Metering.Services
{
    public class CustomerAccountService : ICustomerAccountsService
    {

        private readonly ILogger<Accounts> _logger;
        private readonly DBConnection connection;

        public CustomerAccountService(ILogger<Accounts> logger,
                           DBConnection _conn)
        {
            _logger = logger;
            connection = _conn;
        }
        public IEnumerable<Accounts> GetAllAccounts()
        {
            return connection.dboAccount.AsEnumerable();
        }

        public Accounts AddAccount(Accounts newItem) => throw new NotImplementedException();
        public Accounts GetAccountById(int id) 
        {
            return connection.dboAccount.Where(ac => ac.AccountId == id).FirstOrDefault();
        }      
        public void RemoveAccount(int id) => throw new NotImplementedException();
    }
}
