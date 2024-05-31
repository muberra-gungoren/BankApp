﻿using BankApp.Domain;
using BankApp.Domain.Services;
using System;


   
        while (true)
        {
            if (ConsoleService.loggedInAccount == null)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Log In");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ConsoleService.SignUp();
                        break;
                    case "2":
                        ConsoleService.LogIn();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Log Out");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ConsoleService.Deposit();
                        break;
                    case "2":
                        ConsoleService.Withdraw();
                        break;
                    case "3":
                        ConsoleService.Transfer();
                        break;
                    case "4":
                        ConsoleService.LogOut();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }


class ConsoleService
{
    private static BankAppService bankAppService = new BankAppService();
    public static Account loggedInAccount = null;

    public static void SignUp()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter identity number: ");
        string identityNumber = Console.ReadLine();


        string email;
        while (true)
        {
            Console.Write("Enter email: ");
            email = Console.ReadLine();
            if (email.EndsWith("@gmail.com"))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid email. Please use an email ending with @gmail.com.");
            }
        }

        string phoneNumber;
        while (true)
        {
            Console.Write("Enter phone number: ");
            phoneNumber = Console.ReadLine();
            if (phoneNumber.All(char.IsDigit))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid phone number. Please enter digits only.");
            }
        }


        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        Console.Write("Enter phone number: ");
       

        string accountNumber = GenerateRandomAccountNumber();

        bankAppService.SignUp(name, surname, identityNumber, email, password, phoneNumber);
    }

    public static void LogIn()
    {
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        loggedInAccount = bankAppService.LogIn(email, password);
        if (loggedInAccount != null)
        {
            Console.WriteLine("Logged in successfully.");
        }
        else
        {
            Console.WriteLine("Invalid email or password.");
        }
    }

    public static void LogOut()
    {
        loggedInAccount = null;
        Console.WriteLine("Logged out successfully.");
    }

    public static void Deposit()
    {
        Console.Write("Enter deposit amount: ");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
        bankAppService.Deposit(loggedInAccount, depositAmount);
    }

    public static void Withdraw()
    {
        Console.Write("Enter withdraw amount: ");
        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
        bankAppService.Withdraw(loggedInAccount, withdrawAmount);
    }

    public static void Transfer()
    {
        Console.Write("Enter recipient account number: ");
        string recipientAccountNumber = Console.ReadLine();
        Console.Write("Enter transfer amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        bankAppService.Transfer(loggedInAccount, recipientAccountNumber, amount);
    }

    private static string GenerateRandomAccountNumber()
    {
        Random random = new Random();
        string accountNumber = string.Empty;
        for (int i = 0; i < 10; i++) // Generate a 10-digit account number
        {
            accountNumber += random.Next(0, 10).ToString();
        }
        return accountNumber;
    }
}
