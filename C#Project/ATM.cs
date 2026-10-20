
using System;
using System.IO;

class ATM
{
    // ATM-ის მთავარი მეთოდი.
    // აქ მომხმარებელს შეუძლია დარეგისტრირება, შესვლა და პროგრამიდან გამოსვლა.
    public static void Start()
    {
        // ვინახავთ ანგარიშების ტექსტური ფაილის მისამართს.
        string filePath = "accounts.txt";

        // თუ ფაილი არ არსებობს, ვქმნით ცარიელ ფაილს.
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }

        bool running = true;

        // მთავარი ATM მენიუ გრძელდება მანამ,
        // სანამ მომხმარებელი Exit-ს არ აირჩევს.
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("ATM");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            // რეგისტრაცია.
            if (choice == "1")
            {
                Register(filePath);
            }
            // ავტორიზაცია.
            else if (choice == "2")
            {
                Login(filePath);
            }
            // პროგრამიდან გამოსვლა.
            else if (choice == "3")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }

    // ახალი მომხმარებლის რეგისტრაციის მეთოდი.
    static void Register(string filePath)
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine() ?? "";

        // ვამოწმებთ, რომ username ცარიელი არ იყოს.
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Username cannot be empty.");
            return;
        }

        Console.Write("Enter password: ");
        string password = Console.ReadLine() ?? "";

        // ვამოწმებთ, რომ password ცარიელი არ იყოს.
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Password cannot be empty.");
            return;
        }

        // ანგარიშის ფორმატია:
        // username|password|balance
        string account = username + "|" + password + "|0";

        // ანგარიშს ვამატებთ ტექსტური ფაილის ბოლოში.
        File.AppendAllText(filePath, account + Environment.NewLine);

        Console.WriteLine("Account created successfully.");
    }

    // მომხმარებლის Login-ის მეთოდი.
    static void Login(string filePath)
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine() ?? "";

        Console.Write("Enter password: ");
        string password = Console.ReadLine() ?? "";

        // ვკითხულობთ accounts.txt-ში არსებულ ყველა ხაზს.
        string[] lines = File.ReadAllLines(filePath);

        // ვამოწმებთ თითოეულ ანგარიშს.
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            // თითოეულ ანგარიშში უნდა იყოს username, password და balance.
            if (parts.Length == 3)
            {
                // ვამოწმებთ ემთხვევა თუ არა შეყვანილი მონაცემები ფაილში შენახულ მონაცემებს.
                if (parts[0] == username && parts[1] == password)
                {
                    // თუ მონაცემები სწორია, მომხმარებელი წარმატებით შედის ანგარიშში.
                    UserMenu(filePath, username);
                    return;
                }
            }
        }

        Console.WriteLine("Invalid username or password.");
    }

    // Login-ის შემდეგ მომხმარებლისთვის ხელმისაწვდომი მენიუ.
    static void UserMenu(string filePath, string username)
    {
        bool loggedIn = true;

        // მომხმარებლის მენიუ გრძელდება Logout-მდე.
        while (loggedIn)
        {
            Console.WriteLine();
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Logout");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                // ანგარიშის ბალანსის ჩვენება.
                double balance = GetBalance(filePath, username);

                Console.WriteLine("Balance: " + balance);
            }
            else if (choice == "2")
            {
                Deposit(filePath, username);
            }
            else if (choice == "3")
            {
                Withdraw(filePath, username);
            }
            else if (choice == "4")
            {
                loggedIn = false;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }

    // მომხმარებლის ბალანსის მიღების მეთოდი.
    static double GetBalance(string filePath, string username)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3 && parts[0] == username)
            {
                // ტექსტურ ფაილში შენახულ ბალანსს double ტიპად ვაქცევთ.
                double.TryParse(parts[2], out double balance);

                return balance;
            }
        }

        return 0;
    }

    // ანგარიშზე თანხის შეტანის მეთოდი.
    static void Deposit(string filePath, string username)
    {
        Console.Write("Enter amount to deposit: ");
        string input = Console.ReadLine() ?? "";

        // ვამოწმებთ, არის თუ არა შეყვანილი თანხა ვალიდური რიცხვი.
        if (!double.TryParse(input, out double amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        // მომხმარებლის მიმდინარე ბალანსს ვიღებთ.
        double balance = GetBalance(filePath, username);

        // ახალ ბალანსს ვანგარიშობთ.
        balance += amount;

        // განახლებულ ბალანსს ვინახავთ ფაილში.
        UpdateBalance(filePath, username, balance);

        Console.WriteLine("Deposit successful.");
    }

    // ანგარიშიდან თანხის გატანის მეთოდი.
    static void Withdraw(string filePath, string username)
    {
        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine() ?? "";

        // ვამოწმებთ თანხის ვალიდურობას.
        if (!double.TryParse(input, out double amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount or insufficient balance.");
            return;
        }

        // ვიღებთ მიმდინარე ბალანსს.
        double balance = GetBalance(filePath, username);

        // არ შეიძლება იმაზე მეტი თანხის გატანა,
        // ვიდრე ანგარიშზე გვაქვს.
        if (amount > balance)
        {
            Console.WriteLine("Invalid amount or insufficient balance.");
            return;
        }

        // თანხას ვაკლებთ მიმდინარე ბალანსს.
        balance -= amount;

        // ახალ ბალანსს ვინახავთ ფაილში.
        UpdateBalance(filePath, username, balance);

        Console.WriteLine("Withdrawal successful.");
    }

    // ფაილში მომხმარებლის ბალანსის განახლების მეთოდი.
    static void UpdateBalance(string filePath, string username, double newBalance)
    {
        string[] lines = File.ReadAllLines(filePath);

        // ახალი ანგარიშების სია.
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts.Length == 3 && parts[0] == username)
            {
                // ძველი ბალანსის ნაცვლად ვინახავთ ახალ ბალანსს.
                lines[i] = parts[0] + "|" + parts[1] + "|" + newBalance;
                break;
            }
        }

        // განახლებულ ინფორმაციას ისევ accounts.txt-ში ვინახავთ.
        File.WriteAllLines(filePath, lines);
    }
}

