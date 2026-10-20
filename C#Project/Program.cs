using System;

class Program
{
    // პროგრამის შესრულება იწყება Main მეთოდიდან.
    static void Main()
    {

        // ცვლადი განსაზღვრავს, უნდა გაგრძელდეს თუ არა პროგრამის მუშაობა.
        bool running = true;

        while (running)
        {

            // მომხმარებელს ვაჩვენებთ პროგრამის მთავარ მენიუს.

            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Guess the Number");
            Console.WriteLine("3. Hangman");
            Console.WriteLine("4. Translator");
            Console.WriteLine("5. ATM");
            Console.WriteLine("6. Student Management");
            Console.WriteLine("7. Exit");
            Console.WriteLine();

            // მომხმარებელს ვთხოვთ, აირჩიოს სასურველი მოქმედება.
            Console.Write("Choose an option: ");


            // ReadLine კითხულობს მომხმარებლის შეყვანილ ტექსტს. 
            // თუ მომხმარებელმა არაფერი შეიყვანა და შედეგი null არის, ვინახავთ ცარიელ ტექსტს.
            string choice = Console.ReadLine() ?? "";


            // მომხმარებლის არჩევანის მიხედვით ვხსნით შესაბამის მოდულს.
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
                Hangman.Start();
            }
            else if (choice == "4")
            {
                Translator.Start();
            }
            else if (choice == "5")
            {
                ATM.Start();
            }
            else if (choice == "6")

            {

                // ვქმნით StudentManager კლასის ობიექტს.
                StudentManager studentManager = new StudentManager();

                // ვიძახებთ მეთოდს, რომელიც სტუდენტების მართვის მენიუს ხსნის.
                studentManager.Start();
            }
            else if (choice == "7")
            {
                // false მნიშვნელობა აჩერებს მთავარ ციკლს და პროგრამა მენიუდან გამოდის.
                running = false;
            }
            else
            {
                // თუ არჩევანი არასწორია, მომხმარებელს ვატყობინებთ.
                Console.WriteLine("Invalid option.");
                Console.WriteLine();
            }
        }
        // მთავარი ციკლის დასრულების შემდეგ ვაჩვენებთ გამოსვლის შეტყობინებას.
        Console.WriteLine("C# Project closed.");
    }
}