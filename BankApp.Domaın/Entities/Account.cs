using System;

namespace BankApp.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string PhoneNumber { get; set; }

        public Account(int id, string name, string surname, string identityNumber, string accountNumber, string email, string password, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            IdentityNumber = identityNumber;
            AccountNumber = accountNumber;
            Email = email;
            Password = password;
            Balance = 0; // Default balance is 0
            PhoneNumber = phoneNumber;
        }

        // Bakiye ekleme metodu
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited: {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        // Para çekme metodu
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount:C}. New balance: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
                return false;
            }
        }
    }
}
