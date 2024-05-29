using BankApp.Domaın.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domaın.Services
{
    public class BankAppService
    {
        private List<Account> accounts = new List<Account>();

        public Account SignUp(string name, string surname, string identidyNumber, string accountNumber, string email, string password, string phoneNumber)
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                Name = name,
                Surname = surname,
                IdentidyNumber = identidyNumber,
                AccountNumber = accountNumber,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                Balance = 0
            };

            accounts.Add(account);

            return account;
        }

      
    }
}
