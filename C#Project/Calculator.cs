
using System;

class Calculator
{

    // ამ მეთოდში მომხმარებელს ვაჩვენებთ კალკულატორის მენიუს
    // და ვამუშავებთ მის არჩევანს.
    public static void Start()
    {
        // running განსაზღვრავს, უნდა გაგრძელდეს თუ არა კალკულატორის მუშაობა.
        bool running = true;

        // while ციკლი გრძელდება მანამ, სანამ running არის true.
        while (running)
        {
            Console.WriteLine("Calculator");
            Console.WriteLine();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            // მომხმარებლის არჩევანს ვინახავთ choice ცვლადში.
            // Console.ReadLine() კითხულობს მონაცემს კონსოლიდან.
            string choice = Console.ReadLine() ?? "";

            // თუ მომხმარებელმა აირჩია 5, კალკულატორი იხურება.
            if (choice == "5")
            {
                running = false;
                continue;
            }

            // ვამოწმებთ, არის თუ არა მომხმარებლის არჩევანი 1-დან 4-მდე.
            // თუ არა, პროგრამა აჩვენებს შეცდომის შეტყობინებას.
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("Invalid option.");
                Console.WriteLine();
                continue;
            }

            // მომხმარებელს შევაყვანინებთ პირველ რიცხვს.
            Console.Write("Enter first number: ");
            string input1 = Console.ReadLine() ?? "";

            double number1;

            // TryParse ამოწმებს, შესაძლებელია თუ არა შეყვანილი ტექსტის რიცხვად გადაქცევა.
            // თუ მონაცემი არასწორია, პროგრამა არ გაჩერდება შეცდომით.
            if (!double.TryParse(input1, out number1))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            // მომხმარებელს შევაყვანინებთ მეორე რიცხვს.
            Console.Write("Enter second number: ");
            string input2 = Console.ReadLine() ?? "";

            double number2;

            // ვამოწმებთ მეორე რიცხვის ვალიდურობას.
            if (!double.TryParse(input2, out number2))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            // result-ში ვინახავთ გამოთვლის საბოლოო შედეგს.
            double result = 0;

            // მომხმარებლის არჩევანის მიხედვით ვასრულებთ შესაბამის მოქმედებას.
            if (choice == "1")
            {
                result = Add(number1, number2);
            }
            else if (choice == "2")
            {
                result = Subtract(number1, number2);
            }
            else if (choice == "3")
            {
                result = Multiply(number1, number2);
            }
            else if (choice == "4")
            {
                // ნულზე გაყოფა შეუძლებელია,
                // ამიტომ ჯერ ვამოწმებთ მეორე რიცხვს.
                if (number2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                    Console.WriteLine();
                    continue;
                }

                result = Divide(number1, number2);
            }

            // საბოლოო შედეგს ვაჩვენებთ მომხმარებელს.
            Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }
    }

    // ორი რიცხვის შეკრების მეთოდი.
    static double Add(double number1, double number2)
    {
        return number1 + number2;
    }

    // ორი რიცხვის გამოკლების მეთოდი.
    static double Subtract(double number1, double number2)
    {
        return number1 - number2;
    }

    // ორი რიცხვის გამრავლების მეთოდი.
    static double Multiply(double number1, double number2)
    {
        return number1 * number2;
    }

    // ორი რიცხვის გაყოფის მეთოდი.
    static double Divide(double number1, double number2)
    {
        return number1 / number2;
    }
}

