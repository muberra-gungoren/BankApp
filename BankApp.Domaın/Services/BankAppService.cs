using System;
using System.Collections.Generic;

namespace BankApp.Domain.Services
{
    public class BankAppService
    {
        private List<Account> accounts = new List<Account>();
        private Account loggedInAccount = null; // Mevcut oturum açmış kullanıcıyı tutar

        public void SignUp(string name, string surname, string identityNumber, string email, string password, string phoneNumber)
        {
            // E-posta adresinin zaten mevcut olup olmadığını kontrol eden bir işlev
            foreach (Account account in accounts)
            {
                if (account.Email == email)
                {
                    Console.WriteLine("Email already exists. Try a different one.");
                    return;
                }
            }

            // Listeye yeni hesap ekle
            accounts.Add(new Account(name, surname, identityNumber, email, password, phoneNumber));
            Console.WriteLine("Account created successfully!");
        }

        public Account LogIn(string email, string password)
        {
            // Hesabın verilen e-posta ve şifreyle mevcut olup olmadığının kontrol edilmesi
            foreach (Account account in accounts)
            {
                if (account.Email == email && account.Password == password)
                {
                    loggedInAccount = account;
                    Console.WriteLine("Logged in successfully!");
                    return loggedInAccount;
                }
            }

            // Eğer Kullanıcı Hesabı Bulunmazsa Verilecek Mesaj
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

<<<<<<< Updated upstream
        
=======
        public Account CreateAccount(string? name, string? surname, string? email, string? password, string? phoneNumber, string? identityNumber)
        {
            throw new NotImplementedException();
        }

        public Account Login(string? email, string? password)
        {
            throw new NotImplementedException();
        }

        public bool DepositMoney(Account currentAccount, decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool WithdrawMoney(Account currentAccount, decimal amount)
        {
            throw new NotImplementedException();
        }
>>>>>>> Stashed changes
    }
}
