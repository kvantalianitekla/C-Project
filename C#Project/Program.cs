using System;

class Program
{
    
    static void Main()
    {
        bool running = true;

        while (running)
        {
           
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Guess the Number");
            Console.WriteLine("3. Hangman");
            Console.WriteLine("4. Translator");
            Console.WriteLine("5. ATM");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                Calculator.Start();
            }
            else if (choice == "2")
            {
                GuessNumber.Start();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Hangman - coming soon.");
                Console.WriteLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Translator - coming soon.");
                Console.WriteLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine("ATM - coming soon.");
                Console.WriteLine();
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                Console.WriteLine();
            }
        }

        Console.WriteLine("C# Project closed.");
    }
}