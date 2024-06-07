using BankApp.Domain;
using BankApp.Domain.Services;

<<<<<<< Updated upstream

   
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

    // Yeni Hesap oluşturma
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

    // Hesaba Giriş
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

    // Çıkış Mesajının verilmesi
    public static void LogOut()
    {
        loggedInAccount = null;
        Console.WriteLine("Logged out successfully.");
    }

    //Mevduat(depozito) İşlemleri
    public static void Deposit()
    {
        Console.Write("Enter deposit amount: ");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
        bankAppService.Deposit(loggedInAccount, depositAmount);
    }

    // Çekim İşlmleri
    public static void Withdraw()
    {
        Console.Write("Enter withdraw amount: ");
        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
        bankAppService.Withdraw(loggedInAccount, withdrawAmount);
    }

    // Transfer İşlemleri
    public static void Transfer()
    {
        Console.Write("Enter recipient account number: ");
        string recipientAccountNumber = Console.ReadLine();

        decimal amount;
        while (true)
        {
            Console.Write("Enter transfer amount: ");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out amount))
            {
                // Giriş geçerli bir decimal değerse döngüden çık
                break;
            }
            else
            {
                // Giriş geçerli değilse hata mesajı ver ve yeniden giriş iste
                Console.WriteLine("Invalid input. Please enter a valid numeric amount.");
            }
        }

        bankAppService.Transfer(loggedInAccount, recipientAccountNumber, amount);
    
}

    //Rastgele Hesap Numarası Oluşturma İşlemi
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
=======
namespace BankApp
{
    class Program
    {
        static BankAppService accountService = new BankAppService();
        
        static Account currentAccount = null;
        private static readonly object transferService;

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                if (currentAccount == null)
                {
                    Console.WriteLine("Bankacılık Uygulamasına Hoş Geldiniz!");
                    Console.WriteLine(" ");
                    Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Giriniz: ");
                    Console.WriteLine("1. Hesap Oluştur");
                    Console.WriteLine("2. Hesaba Giriş");
                    Console.WriteLine("3. Çıkış");
                    Console.Write("Lütfen bir seçenek girin: ");
                    string initialChoice = Console.ReadLine();

                    if (initialChoice == "1")
                    {
                        CreateAccount();
                    }
                    else if (initialChoice == "2")
                    {
                        Login();
                    }
                    else if (initialChoice == "3")
                    {
                        running = false;
                        Console.WriteLine("Çıkış yapılıyor...");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                    }
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Giriniz: ");
                    Console.WriteLine("1. Bakiye Sorgulama");
                    Console.WriteLine("2. Para Yatırma");
                    Console.WriteLine("3. Para Çekme");
                    Console.WriteLine("4. Para Gönderme");
                    Console.WriteLine("5. Çıkış");
                    Console.Write("Lütfen bir seçenek girin: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        CheckBalance();
                    }
                    else if (choice == "2")
                    {
                        DepositMoney();
                    }
                    else if (choice == "3")
                    {
                        WithdrawMoney();
                    }
                    else if (choice == "4")
                    {
                        TransferMoney();
                    }
                    else if (choice == "5")
                    {
                        currentAccount = null;
                        Console.WriteLine("Çıkış yapılıyor...");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                    }
                }

                Console.WriteLine();
            }
        }

        static void CreateAccount()
        {
            Console.Write("Adınızı girin: ");
            string name = Console.ReadLine();

            Console.Write("Soyadınızı girin: ");
            string surname = Console.ReadLine();

            Console.Write("E-posta adresinizi girin: ");
            string email = Console.ReadLine();

            Console.Write("Şifrenizi oluşturun: ");
            string password = Console.ReadLine();
            Console.WriteLine("Şifreniz başarıyla oluşturuldu!");

            Console.Write("Telefon numaranızı girin: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Kimlik numaranızı girin: ");
            string identityNumber = Console.ReadLine();

            Account newAccount = accountService.CreateAccount(name, surname, email, password, phoneNumber, identityNumber);
            Console.WriteLine($"Hesap başarıyla oluşturuldu! Hesap Numarası: {newAccount.AccountNumber}");
        }

        static void Login()
        {
            Console.Write("E-posta adresinizi girin: ");
            string email = Console.ReadLine();

            Console.Write("Şifrenizi girin: ");
            string password = Console.ReadLine();

            currentAccount = accountService.Login(email, password);
            if (currentAccount != null)
            {
                Console.WriteLine($"Giriş başarılı! Hoş geldiniz, {currentAccount.Name} {currentAccount.Surname}");
            }
            else
            {
                Console.WriteLine("Geçersiz e-posta veya şifre.");
            }
        }

        static void CheckBalance()
        {
            if (currentAccount != null)
            {
                Console.WriteLine($"Hesap Numarası: {currentAccount.AccountNumber}, Bakiye: {currentAccount.Balance} TL");
            }
            else
            {
                Console.WriteLine("Giriş yapmanız gerekmektedir.");
            }
        }

        static void DepositMoney()
        {
            if (currentAccount != null)
            {
                Console.Write("Yatırmak istediğiniz miktarı girin: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    if (accountService.DepositMoney(currentAccount, amount))
                    {
                        Console.WriteLine($"Yeni bakiye: {currentAccount.Balance} TL");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz miktar.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz miktar.");
                }
            }
            else
            {
                Console.WriteLine("Giriş yapmanız gerekmektedir.");
            }
        }

        static void WithdrawMoney()
        {
            if (currentAccount != null)
            {
                Console.Write("Çekmek istediğiniz miktarı girin: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    if (accountService.WithdrawMoney(currentAccount, amount))
                    {
                        Console.WriteLine($"Yeni bakiye: {currentAccount.Balance} TL");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz miktar.");
                }
            }
            else
            {
                Console.WriteLine("Giriş yapmanız gerekmektedir.");
            }
        }

        static void TransferMoney()
        {
            if (currentAccount != null)
            {
                Console.Write("Alıcı hesap numarasını girin: ");
                string receiverAccountNumber = Console.ReadLine();

                Console.Write("Transfer etmek istediğiniz miktarı girin: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    if (!transferService.TransferMoney(currentAccount.AccountNumber, receiverAccountNumber, amount))
                    {
                        Console.WriteLine("Yetersiz bakiye veya geçersiz alıcı hesap numarası.");
                    }
                    else
                    {
                        Console.WriteLine($"Transfer başarılı! Gönderen yeni bakiye: {currentAccount.Balance} TL");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz miktar.");
                }
            }
            else
            {
                Console.WriteLine("Giriş yapmanız gerekmektedir.");
            }
        }
    }
}
>>>>>>> Stashed changes
