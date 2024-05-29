
using BankApp.Domaın.Services;


BankAppService bankAppService = new ();

Console.Write("Enter name: ");
string name = Console.ReadLine();
Console.Write("Enter surname: ");
string surname = Console.ReadLine();
Console.Write("Enter identidy number: ");
string identidyNumber = Console.ReadLine();
Console.Write("Enter account number: ");
string accountNumber = Console.ReadLine();
Console.Write("Enter email: ");
string email = Console.ReadLine();
Console.Write("Enter password: ");
string password = Console.ReadLine();
Console.Write("Enter phone number: ");
string phoneNumber = Console.ReadLine();



bankAppService.SignUp( name, surname, identidyNumber, accountNumber,  email, password, phoneNumber);





    Console.Write("Enter email: ");
    string email = Console.ReadLine();
    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    // BankAppService ile giriş işlemini gerçekleştir
    bankAppService.LogIn(email, password);






