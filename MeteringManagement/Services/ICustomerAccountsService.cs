using Metering.Model;
using System.Collections.Generic;

namespace Metering.Services
{
    public interface ICustomerAccountsService
    {
        IEnumerable<Accounts> GetAllAccounts();
        Accounts AddAccount(Accounts newAccount);
        Accounts GetAccountById(int id);
        void RemoveAccount(int id);
    }
}
