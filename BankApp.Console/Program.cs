using BankApp.Domain;
using BankApp.Domain.Services;
using System;

namespace BankConsoleApp
{
    public class Program
    {
        private static BankAppService bankAppService = new BankAppService();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Log In");
                Console.WriteLine("3.Deposit");
                Console.WriteLine("4.Withdraw");
                Console.WriteLine("5.Transfer");
                Console.WriteLine("6.Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Enter identity number: ");
                        string identityNumber = Console.ReadLine();
                        Console.Write("Enter account number: ");
                        string accountNumber = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();

                        bankAppService.SignUp(name, surname, identityNumber, accountNumber, email, password, phoneNumber);

                        break;

                    case "2":
                        Console.Write("Enter email: ");
                        string logInEmail = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string logInPassword = Console.ReadLine();

                        bankAppService.LogIn(logInEmail, logInPassword);

                        break;

                    case "3":
                        Console.Write("Enter deposit amount: ");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        bankAppService.Deposit(depositAmount);
                        break;
                    case "4":
                        Console.Write("Enter Withdraw amount: ");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        bankAppService.Withdraw(withdrawAmount);

                        break;

                    case "5":
                        Console.Write("Enter recipient Account Number: ");
                        string recipientAccountNumber = Console.ReadLine();
                        Console.Write("Enter Transfer amount: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());

                        bankAppService.Transfer(recipientAccountNumber, amount);
                        break;
                        
                      case "6":
                        Environment.Exit(0);
                        break;
                }

            }

    }   
   }
    }
      



