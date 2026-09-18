using System;

class GuessNumber
{
    
    public static void Start()
    {
        Random random = new Random();
        int number = random.Next(1, 101);

        int attempts = 0;
        bool guessed = false;

        Console.WriteLine();
        Console.WriteLine("Guess the Number");
        Console.WriteLine("I chose a number between 1 and 100.");

        while (!guessed)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine() ?? "";

            int guess;

            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            attempts++;

            if (guess == number)
            {
                guessed = true;
                Console.WriteLine("Correct!");
                Console.WriteLine("Attempts: " + attempts);
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher!");
            }
            else
            {
                Console.WriteLine("Lower!");
            }
        }

        Console.WriteLine();
    }
}