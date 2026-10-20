
using System;

class Hangman
{
    
    // ამ მეთოდში მომხმარებელი ცდილობს დამალული სიტყვის გამოცნობას.
    public static void Start()
    {
        // სიტყვების მასივი, საიდანაც პროგრამა შემთხვევით აირჩევს ერთ სიტყვას.
        string[] words = { "minecraft", "batman", "skillissue", "amongus", "ironman" };

        // Random-ის გამოყენებით ვირჩევთ შემთხვევით სიტყვას მასივიდან.
        Random random = new Random();
        string word = words[random.Next(words.Length)];

        // აქ ვინახავთ უკვე გამოცნობილ ასოებს.
        string guessedLetters = "";

        // მომხმარებელს აქვს 6 მცდელობა.
        int attempts = 6;

        // თამაში გრძელდება მანამ, სანამ მცდელობები დარჩენილია
        // და სიტყვა მთლიანად არ არის გამოცნობილი.
        while (attempts > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Hangman");

            // ვაჩვენებთ სიტყვის თითოეულ ასოს ან ქვედა ხაზს,
            // თუ შესაბამისი ასო ჯერ არ არის გამოცნობილი.
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];

                if (guessedLetters.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Attempts left: " + attempts);

            // ვამოწმებთ, მთლიანად გამოიცნო თუ არა მომხმარებელმა სიტყვა.
            bool complete = true;

            for (int i = 0; i < word.Length; i++)
            {
                if (!guessedLetters.Contains(word[i]))
                {
                    complete = false;
                    break;
                }
            }

            // თუ ყველა ასო გამოცნობილია, თამაში დასრულებულია.
            if (complete)
            {
                Console.WriteLine("You guessed the word!");
                Console.WriteLine("The word was: " + word);
                return;
            }

            // მომხმარებელს შევაყვანინებთ ერთ ასოს.
            Console.Write("Enter a letter: ");
            string input = Console.ReadLine() ?? "";

            // ვამოწმებთ, რომ მომხმარებელმა მხოლოდ ერთი ასო შეიყვანა.
            if (input.Length != 1)
            {
                Console.WriteLine("Please enter one letter.");
                continue;
            }

            // ასოს გადავიყვანთ პატარა ასოდ.
            char guess = char.ToLower(input[0]);

            // ვამოწმებთ, უკვე ხომ არ არის ეს ასო გამოცნობილი.
            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter.");
                continue;
            }

            // ახალ გამოცნობილ ასოს ვამატებთ guessedLetters-ში.
            guessedLetters += guess;

            // ვამოწმებთ, არის თუ არა ეს ასო დამალულ სიტყვაში.
            if (word.Contains(guess))
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                // თუ ასო სიტყვაში არ არის, მცდელობების რაოდენობა მცირდება.
                Console.WriteLine("Wrong!");
                attempts--;
            }
        }

        // თუ მცდელობები ამოიწურა, თამაში დასრულებულია.
        Console.WriteLine();
        Console.WriteLine("Game over!");
        Console.WriteLine("The word was: " + word);
    }
}

