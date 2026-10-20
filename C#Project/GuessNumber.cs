
using System;

class GuessNumber
{

    // ამ მეთოდში იქმნება შემთხვევითი რიცხვი და მომხმარებელი ცდილობს მის გამოცნობას.
    public static void Start()
    {
        // Random კლასი გამოიყენება შემთხვევითი რიცხვის შესაქმნელად.
        Random random = new Random();

        // იქმნება შემთხვევითი რიცხვი 1-დან 100-მდე.
        int number = random.Next(1, 101);

        // attempts ითვლის მომხმარებლის მცდელობების რაოდენობას.
        int attempts = 0;

        // guessed აჩვენებს, გამოიცნო თუ არა მომხმარებელმა რიცხვი.
        bool guessed = false;

        Console.WriteLine();
        Console.WriteLine("Guess the Number");
        Console.WriteLine("I chose a number between 1 and 100.");

        // თამაში გრძელდება მანამ, სანამ რიცხვი არ იქნება გამოცნობილი.
        while (!guessed)
        {
            Console.Write("Enter your guess: ");

            // მომხმარებლის შეყვანილ მონაცემს ვინახავთ input-ში.
            string input = Console.ReadLine() ?? "";

            int guess;

            // ვამოწმებთ, არის თუ არა მომხმარებლის შეყვანილი მონაცემი ვალიდური მთელი რიცხვი.
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            // ყოველ სწორად შეყვანილ რიცხვზე მცდელობების რაოდენობა იზრდება.
            attempts++;

            // თუ მომხმარებლის რიცხვი დამალულ რიცხვს ემთხვევა,
            // თამაში სრულდება.
            if (guess == number)
            {
                guessed = true;

                Console.WriteLine("Correct!");
                Console.WriteLine("Attempts: " + attempts);
            }
            // თუ გამოცნობილი რიცხვი ნაკლებია დამალულ რიცხვზე,
            // მომხმარებელს ვეუბნებით, რომ უფრო მაღალი რიცხვი სცადოს.
            else if (guess < number)
            {
                Console.WriteLine("Higher!");
            }
            // სხვა შემთხვევაში მომხმარებელს ვეუბნებით,
            // რომ უფრო დაბალი რიცხვი სცადოს.
            else
            {
                Console.WriteLine("Lower!");
            }
        }

        Console.WriteLine();
    }
}

