using LINQ_Assignment_Task2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignment_Task2
{
    class Program
    {
        static void Main()
        {
            // Sample list of Person objects
            List<Person> people = new List<Person>
        {
            new Person { FirstName = "Shubham", LastName = "K", Age = 32, Gender = "Male", Salary = 50000 },
            new Person { FirstName = "Swarali", LastName = "D", Age = 28, Gender = "Female", Salary = 60000 },
            new Person { FirstName = "Arpan", LastName = "M", Age = 45, Gender = "Male", Salary = 70000 },
            new Person { FirstName = "Bhakti", LastName = "S", Age = 34, Gender = "Female", Salary = 55000 },
            new Person { FirstName = "Sangram", LastName = "P", Age = 30, Gender = "Male", Salary = 45000 }
        };

            // a) Calculate the average age of all persons
            double averageAge = people.Average(p => p.Age);
            Console.WriteLine($"The average age of all persons is: {averageAge:F2}");

            // b) Find and print the oldest and youngest person's full name
            var oldestPerson = people.OrderByDescending(p => p.Age).First();
            var youngestPerson = people.OrderBy(p => p.Age).First();

            Console.WriteLine($"\nOldest person: {oldestPerson.FirstName} {oldestPerson.LastName}, Age: {oldestPerson.Age}");
            Console.WriteLine($"Youngest person: {youngestPerson.FirstName} {youngestPerson.LastName}, Age: {youngestPerson.Age}");
        }
    }
}