
//==========================================================CALCULATOR=====================================================
using System;

class Program
{
    static double Add(double number1, double number2)
    {
        return number1 + number2;
    }

    static double Subtract(double number1, double number2)
    {
        return number1 - number2;
    }

    static double Multiply(double number1, double number2)
    {
        return number1 * number2;
    }

    static double Divide(double number1, double number2)
    {
        return number1 / number2;
    }

    static void Main()
    {
        bool running = true;

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

            string choice = Console.ReadLine();

            if (choice == "5")
            {
                running = false;
                continue;
            }

            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("Invalid option.");
                Console.WriteLine();
                continue;
            }

            Console.Write("Enter first number: ");
            string input1 = Console.ReadLine();

            double number1;

            if (!double.TryParse(input1, out number1))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            Console.Write("Enter second number: ");
            string input2 = Console.ReadLine();

            double number2;

            if (!double.TryParse(input2, out number2))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            double result = 0;

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
                if (number2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                    Console.WriteLine();
                    continue;
                }

                result = Divide(number1, number2);
            }

            Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }

        Console.WriteLine("Calculator closed.");
    }
}