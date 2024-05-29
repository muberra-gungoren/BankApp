using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domaın.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set;}

        public string Surname { get; set;}

        public string IdentidyNumber { get; set;}

        public string AccountNumber { get; set;}

        public string Email { get; set;}

        public string Password { get; set;}

        public decimal Balance { get; set;}

        public string PhoneNumber { get; set;}
    }
}
