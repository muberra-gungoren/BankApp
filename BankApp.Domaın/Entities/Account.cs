using System;
using System.Linq;

namespace BankApp.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string PhoneNumber { get; set; }

        private static Random random = new Random();

        public Account(string name, string surname, string identityNumber, string email, string password, string phoneNumber)
        {
            Id = Guid.NewGuid();  // Guid tipinde Id oluşturma
            Name = name;
            Surname = surname;
            IdentityNumber = identityNumber;
            AccountNumber = GenerateRandomAccountNumber();  // Rastgele hesap numarası oluşturma
            Email = email;
            Password = password;
            Balance = 0; // Varsayılan bakiye 0
            PhoneNumber = phoneNumber;
        }

        // Rastgele bir hesap numarası oluşturma metodu
        private string GenerateRandomAccountNumber()
        {
            const int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
