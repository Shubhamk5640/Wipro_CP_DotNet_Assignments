using LINQ_Assignment_Task1;
using System;

namespace LINQ_Assignment_Task1
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

            // a) Use LINQ to select and print names of all persons whose age is over 30
            var peopleOver30 = people.Where(p => p.Age > 30)
                                     .Select(p => $"{p.FirstName} {p.LastName}");

            Console.WriteLine("People over 30:");
            foreach (var name in peopleOver30)
            {
                Console.WriteLine(name);
            }

            // b) Order the persons by last name and then by first name and print the sorted list
            var sortedPeople = people.OrderBy(p => p.LastName)
                                     .ThenBy(p => p.FirstName);

            Console.WriteLine("\nSorted people by last name and then by first name:");
            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}, Age: {person.Age}");
            }
        }
    }
}