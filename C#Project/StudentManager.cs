
using System;
using System.Collections.Generic;

class StudentManager
{
    // List ინახავს სტუდენტების ობიექტებს.
    private List<Student> students = new List<Student>();

    // იწყებს სტუდენტების მართვის სისტემას.
    public void Start()
    {
        // running განსაზღვრავს, უნდა გაგრძელდეს თუ არა მენიუს მუშაობა.
        bool running = true;

        // მენიუ მეორდება, სანამ running-ის მნიშვნელობა true-ა.
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Student Management System");
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Grade");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            // კითხულობს მომხმარებლის მიერ არჩეულ მენიუს პუნქტს.
            string choice = Console.ReadLine() ?? "";

            // არჩევანის მიხედვით იძახებს შესაბამის მეთოდს.
            if (choice == "1")
            {
                AddStudent();
            }
            else if (choice == "2")
            {
                ViewAllStudents();
            }
            else if (choice == "3")
            {
                SearchStudent();
            }
            else if (choice == "4")
            {
                UpdateGrade();
            }
            else if (choice == "5")
            {
                DeleteStudent();
            }
            else if (choice == "6")
            {
                // false აჩერებს while ციკლს.
                running = false;
            }
            else
            {
                // ეს შეტყობინება გამოჩნდება არასწორი არჩევანის შემთხვევაში.
                Console.WriteLine("Invalid option.");
            }
        }
    }

    // ამატებს ახალ სტუდენტს სიაში.
    private void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "";

        // ამოწმებს, ცარიელია თუ არა სახელი ან შეიცავს მხოლოდ გამოტოვებებს.
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            return; // წყვეტს მეთოდის შესრულებას.
        }

        Console.Write("Enter roll number: ");
        string input = Console.ReadLine() ?? "";

        // TryParse ამოწმებს, შესაძლებელია თუ არა ტექსტის მთელ რიცხვად გარდაქმნა.
        // ასევე ამოწმებს, რომ ნომერი ნულზე მეტი იყოს.
        if (!int.TryParse(input, out int rollNumber) || rollNumber <= 0)
        {
            Console.WriteLine("Please enter a valid positive number.");
            return;
        }

        // foreach ციკლი ამოწმებს სიაში არსებულ ყველა სტუდენტს.
        foreach (Student student in students)
        {
            // ამოწმებს, აქვს თუ არა რომელიმე სტუდენტს იგივე ნომერი.
            if (student.RollNumber == rollNumber)
            {
                Console.WriteLine("A student with this roll number already exists.");
                return;
            }
        }

        Console.Write("Enter grade: ");
        string gradeInput = Console.ReadLine() ?? "";

        // ამოწმებს, რომ შეფასება მხოლოდ ერთი სიმბოლოსგან შედგებოდეს.
        if (gradeInput.Length != 1)
        {
            Console.WriteLine("Please enter one letter for the grade.");
            return;
        }

        // ToUpper შეყვანილ ასოს დიდ ასოდ გარდაქმნის.
        char grade = char.ToUpper(gradeInput[0]);

        // ამოწმებს, არის თუ არა შეფასება A, B, C, D ან F.
        if (grade != 'A' &&
            grade != 'B' &&
            grade != 'C' &&
            grade != 'D' &&
            grade != 'F')
        {
            Console.WriteLine("Invalid grade.");
            return;
        }

        // ქმნის Student კლასის ახალ ობიექტს კონსტრუქტორის გამოყენებით.
        Student studentToAdd = new Student(name, rollNumber, grade);

        // ახალ სტუდენტს ამატებს students სიაში.
        students.Add(studentToAdd);

        Console.WriteLine("Student added successfully.");
    }

    // აჩვენებს ყველა სტუდენტს.
    private void ViewAllStudents()
    {
        // Count აბრუნებს სიაში არსებული ელემენტების რაოდენობას.
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("All Students");

        // foreach ციკლი სათითაოდ გადის ყველა სტუდენტზე.
        foreach (Student student in students)
        {
            Console.WriteLine();

            // აჩვენებს სტუდენტის სახელს, ნომერსა და შეფასებას.
            student.DisplayInfo();
        }
    }

    // ეძებს სტუდენტს მისი ნომრის მიხედვით.
    private void SearchStudent()
    {
        Console.Write("Enter roll number: ");
        string input = Console.ReadLine() ?? "";

        // ამოწმებს, შესაძლებელია თუ არა შეყვანილი ტექსტის მთელ რიცხვად გარდაქმნა.
        if (!int.TryParse(input, out int rollNumber))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        // ამოწმებს სიაში არსებულ თითოეულ სტუდენტს.
        foreach (Student student in students)
        {
            // ადარებს სტუდენტის ნომერს მომხმარებლის მიერ შეყვანილ ნომერს.
            if (student.RollNumber == rollNumber)
            {
                Console.WriteLine();

                // აჩვენებს ნაპოვნი სტუდენტის ინფორმაციას.
                student.DisplayInfo();
                return;
            }
        }

        // თუ სტუდენტი ვერ მოიძებნა, აჩვენებს შეტყობინებას.
        Console.WriteLine("Student not found.");
    }

    // ცვლის სტუდენტის შეფასებას.
    private void UpdateGrade()
    {
        Console.Write("Enter roll number: ");
        string input = Console.ReadLine() ?? "";

        // ამოწმებს, სწორად არის თუ არა შეყვანილი სტუდენტის ნომერი.
        if (!int.TryParse(input, out int rollNumber))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        // ეძებს სტუდენტს მისი ნომრის მიხედვით.
        foreach (Student student in students)
        {
            if (student.RollNumber == rollNumber)
            {
                Console.Write("Enter new grade: ");
                string gradeInput = Console.ReadLine() ?? "";

                // ამოწმებს, რომ შეფასება ერთი სიმბოლო იყოს.
                if (gradeInput.Length != 1)
                {
                    Console.WriteLine("Please enter one letter for the grade.");
                    return;
                }

                // შეყვანილ ასოს დიდ ასოდ გარდაქმნის.
                char newGrade = char.ToUpper(gradeInput[0]);

                // ამოწმებს, არის თუ არა ახალი შეფასება დასაშვები.
                if (newGrade != 'A' &&
                    newGrade != 'B' &&
                    newGrade != 'C' &&
                    newGrade != 'D' &&
                    newGrade != 'F')
                {
                    Console.WriteLine("Invalid grade.");
                    return;
                }

                // Grade თვისების set ნაწილის გამოყენებით ცვლის შეფასებას.
                student.Grade = newGrade;

                Console.WriteLine("Grade updated successfully.");
                return;
            }
        }

        // თუ შესაბამისი სტუდენტი ვერ მოიძებნა.
        Console.WriteLine("Student not found.");
    }

    // შლის სტუდენტს მისი ნომრის მიხედვით.
    private void DeleteStudent()
    {
        Console.Write("Enter the roll number of the student to delete: ");
        string input = Console.ReadLine() ?? "";

        // ამოწმებს, სწორად არის თუ არა შეყვანილი ნომერი.
        if (!int.TryParse(input, out int rollNumber))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        // ეძებს სტუდენტს სიაში.
        foreach (Student student in students)
        {
            if (student.RollNumber == rollNumber)
            {
                // შლის ნაპოვნ სტუდენტს სიიდან.
                students.Remove(student);

                Console.WriteLine("Student deleted successfully.");
                return;
            }
        }

        // თუ სტუდენტი ვერ მოიძებნა, აჩვენებს შეტყობინებას.
        Console.WriteLine("Student not found.");
    }
}

