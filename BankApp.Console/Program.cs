
using BankApp.Domaın.Services;


BankAppService bankAppService = new ();
string name = Console.ReadLine();
string surname = Console.ReadLine();
string identidyNumber = Console.ReadLine();
string accountNumber = Console.ReadLine();
string email = Console.ReadLine();
string password = Console.ReadLine();
string phoneNumber = Console.ReadLine();

    bankAppService.SignUp( name, surname, identidyNumber, accountNumber,  email, password, phoneNumber);
  
