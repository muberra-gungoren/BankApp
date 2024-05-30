using System;
using System.Collections.Generic;

namespace BankApp.Domain.Services
{
    public class BankAppService
    {
        private List<Account> accounts = new List<Account>();
        private int nextId = 1; // Unique ID generator
        private Account loggedInAccount = null; // Mevcut oturum açmış kullanıcıyı tutar

        public void SignUp(string name, string surname, string identityNumber, string accountNumber, string email, string password, string phoneNumber)
        {
            // Check if the email already exists
            foreach (Account account in accounts)
            {
                if (account.Email == email)
                {
                    Console.WriteLine("Email already exists. Try a different one.");
                    return;
                }
            }

            // Add new account to the list
            accounts.Add(new Account(nextId++, name, surname, identityNumber, accountNumber, email, password, phoneNumber));
            Console.WriteLine("Account created successfully!");
        }

        public Account LogIn(string email, string password)
        {
            // Check if the account exists with the given email and password
            foreach (Account account in accounts)
            {
                if (account.Email == email && account.Password == password)
                {
                    loggedInAccount = account;
                    Console.WriteLine("Logged in successfully!");
                    return loggedInAccount;
                }
            }

            // If no account is found
            Console.WriteLine("Invalid email or password.");
            return null;
        }

        public void Deposit(Account loggedInAccount, decimal amount)
        {
            if (loggedInAccount != null)
            {
                loggedInAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("You need to log in first.");
            }
        }

        public void Withdraw(Account loggedInAccount, decimal amount)
        {
            if (loggedInAccount != null)
            {
                loggedInAccount.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("You need to log in first.");
            }
        }

        public void Transfer(Account loggedInAccount, string recipientAccountNumber, decimal amount)
        {
            // Kullanıcı girişi yapılmış mı kontrol et
            if (loggedInAccount == null)
            {
                Console.WriteLine("You need to log in first.");
                return;
            }
            // Alıcı hesabını bul
            Account recipientAccount = null;
            foreach (var account in accounts)
            {
                if (account.AccountNumber == recipientAccountNumber)
                {
                    recipientAccount = account;
                    break;
                }
            }

            if (recipientAccount == null)
            {
                Console.WriteLine("Recipient account not found.");
                return;
            }

            // Para transferi yap
            if (loggedInAccount.Withdraw(amount))
            {
                recipientAccount.Deposit(amount);
                Console.WriteLine($"Transferred {amount:C} to {recipientAccount.Name}'s account ({recipientAccount.AccountNumber}).");
            }
            else
            {
                Console.WriteLine("Transfer failed.");
            }
        }

        public Account GetLoggedInAccount()
        {
            return loggedInAccount;
        }

        public void SignUp(string? name, string? surname, string? identityNumber, string? email, string? password, string? phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
