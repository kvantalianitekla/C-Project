
using System;
using System.IO;
using System.Text;

class Translator
{

    // აქ მომხმარებელს შეუძლია თარგმანის მოძებნა ან ახალი თარგმანის დამატება.
    public static void Start()
    {
        // ვინახავთ ტექსტური ფაილის მისამართს.
        string filePath = "translations.txt";

        // თუ ფაილი არ არსებობს, ვქმნით ახალ ცარიელ ფაილს.
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "", Encoding.UTF8);
        }

        // running განსაზღვრავს, უნდა გაგრძელდეს თუ არა Translator-ის მუშაობა.
        bool running = true;

        // მენიუ მეორდება მანამ, სანამ მომხმარებელი Exit-ს არ აირჩევს.
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Translator");
            Console.WriteLine("1. Georgian to English");
            Console.WriteLine("2. English to Georgian");
            Console.WriteLine("3. Delete Translation File");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            // მომხმარებლის არჩევანს ვინახავთ choice ცვლადში.
            string choice = Console.ReadLine() ?? "";

            // თუ მომხმარებელმა აირჩია 4, Translator იხურება.
            if (choice == "4")
            {
                running = false;
            }

            // თუ მომხმარებელმა აირჩია 3, შეგვიძლია ფაილის წაშლა.
            else if (choice == "3")
            {
                Console.Write("Are you sure you want to delete all saved translations? (yes/no): ");

                // მომხმარებელს ვთხოვთ დაადასტუროს ფაილის წაშლა.
                string answer = Console.ReadLine() ?? "";

                if (answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    // ვამოწმებთ, არსებობს თუ არა ფაილი.
                    if (File.Exists(filePath))
                    {
                        // File.Delete() შლის translations.txt ფაილს.
                        File.Delete(filePath);

                        Console.WriteLine("Translation file deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Translation file does not exist.");
                    }
                }
                else
                {
                    // თუ მომხმარებელმა yes არ შეიყვანა, წაშლა არ ხდება.
                    Console.WriteLine("Deletion cancelled.");
                }
            }

            // 1 და 2 გამოიყენება თარგმანის მოსაძებნად.
            else if (choice == "1" || choice == "2")
            {
                // თუ ფაილი წაშლილია, პროგრამა თავიდან ქმნის მას.
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "", Encoding.UTF8);
                }

                Console.Write("Enter a word: ");

                // მომხმარებლის მიერ შეყვანილ სიტყვას ვინახავთ word-ში.
                string word = Console.ReadLine() ?? "";

                // ReadAllLines კითხულობს ტექსტურ ფაილში არსებულ ყველა ხაზს.
                // თითოეული ხაზი ინახება lines მასივში.
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                // found გვიჩვენებს, ვიპოვეთ თუ არა სასურველი თარგმანი.
                bool found = false;

                // foreach ციკლით ვამოწმებთ ფაილში არსებულ თითოეულ ხაზს.
                foreach (string line in lines)
                {
                    // თითოეულ ხაზს ვყოფთ "|" სიმბოლოს მიხედვით.
                    // მარცხენა ნაწილი არის სიტყვა, მარჯვენა კი მისი თარგმანი.
                    string[] parts = line.Split('|');

                    // ვამოწმებთ, რომ ხაზში ნამდვილად ორი ნაწილი გვაქვს.
                    if (parts.Length == 2)
                    {
                        // თუ არჩეულია Georgian to English,
                        // ვეძებთ ქართულ სიტყვას.
                        if (choice == "1" &&
                            parts[0].Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Translation: " + parts[1]);

                            // თარგმანი ვიპოვეთ.
                            found = true;

                            break;
                        }

                        // თუ არჩეულია English to Georgian,
                        // ვეძებთ ინგლისურ სიტყვას.
                        else if (choice == "2" &&
                                 parts[1].Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Translation: " + parts[0]);

                            // თარგმანი ვიპოვეთ.
                            found = true;

                            break;
                        }
                    }
                }

                // თუ თარგმანი ვერ ვიპოვეთ, მომხმარებელს ვთავაზობთ მის დამატებას.
                if (!found)
                {
                    Console.WriteLine("Translation not found.");

                    Console.Write("Would you like to add this translation? (yes/no): ");

                    string answer = Console.ReadLine() ?? "";

                    if (answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter the translation: ");

                        // მომხმარებელს შემოაქვს ახალი თარგმანი.
                        string translation = Console.ReadLine() ?? "";

                        // AppendAllText ახალ თარგმანს ამატებს ტექსტური ფაილის ბოლოში.
                        if (choice == "1")
                        {
                            File.AppendAllText(
                                filePath,
                                word + "|" + translation + Environment.NewLine,
                                Encoding.UTF8);
                        }
                        else
                        {
                            File.AppendAllText(
                                filePath,
                                translation + "|" + word + Environment.NewLine,
                                Encoding.UTF8);
                        }

                        Console.WriteLine("Translation added.");
                    }
                }
            }

            // თუ მომხმარებელმა სხვა რამ შეიყვანა, ვაჩვენებთ შეცდომას.
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}


