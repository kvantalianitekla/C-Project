
using System;


class Person
{

    public string Name { get; set; }

    // კონსტრუქტორი, რომელიც ობიექტის შექმნისას სახელს იღებს.
    public Person(string name)
    {
        Name = name;
    }

    // virtual საშუალებას გვაძლევს, მემკვიდრე კლასში ეს მეთოდი გადავფაროთ.
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Name: " + Name);
    }
}

// Student კლასი მემკვიდრეობით იღებს Person კლასის თვისებებსა და მეთოდებს.
class Student : Person
{
    // private ველები პირდაპირ ხელმისაწვდომია მხოლოდ ამ კლასის შიგნით.
    private int rollNumber;
    private char grade;

    // Student-ის კონსტრუქტორი იღებს სახელს, ნომერსა და შეფასებას.
    // base(name) იძახებს მშობელი კლასის (Person) კონსტრუქტორს.
    public Student(string name, int rollNumber, char grade) : base(name)
    {
        this.rollNumber = rollNumber;
        this.grade = grade;
    }

    // RollNumber თვისება აბრუნებს სტუდენტის ნომერს.
    public int RollNumber
    {
        get { return rollNumber; }
    }

    // Grade თვისება საშუალებას გვაძლევს, წავიკითხოთ და შევცვალოთ შეფასება.
    public char Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    // override ცვლის მშობელი კლასის DisplayInfo მეთოდის ქცევას.
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // იძახებს Person კლასის DisplayInfo მეთოდს და აჩვენებს სახელს.
        Console.WriteLine("Roll Number: " + RollNumber);
        Console.WriteLine("Grade: " + Grade);
    }
}
