using LINQ_Practice;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sample list of Person objects
        List<Person> people = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe", Age = 32, Gender = "Male", Salary = 50000 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 28, Gender = "Female", Salary = 60000 },
            new Person { FirstName = "Michael", LastName = "Johnson", Age = 45, Gender = "Male", Salary = 70000 },
            new Person { FirstName = "Emily", LastName = "Davis", Age = 34, Gender = "Female", Salary = 55000 },
            new Person { FirstName = "David", LastName = "Wilson", Age = 30, Gender = "Male", Salary = 45000 },
            new Person { FirstName = "Chris", LastName = "Brown", Age = 32, Gender = "Male", Salary = 48000 },
            new Person { FirstName = "Anna", LastName = "Williams", Age = 42, Gender = "Female", Salary = 68000 }
        };

        // 1. Aggregating Data: Sum, Average, Min, Max
        var totalSalary = people.Sum(p => p.Salary);
        var averageAge = people.Average(p => p.Age);
        var maxSalary = people.Max(p => p.Salary);
        var minSalary = people.Min(p => p.Salary);

        Console.WriteLine($"Total Salary: {totalSalary}");
        Console.WriteLine($"Average Age: {averageAge}");
        Console.WriteLine($"Maximum Salary: {maxSalary}");
        Console.WriteLine($"Minimum Salary: {minSalary}");

        // 2. Where Clause: Filter data based on conditions
        var peopleOver30 = people.Where(p => p.Age > 30);
        Console.WriteLine("\nPeople over 30:");
        foreach (var person in peopleOver30)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}, Age: {person.Age}");
        }

        // 3. Group By Clause: Group data by a specific property
        var groupedByGender = people.GroupBy(p => p.Gender);
        Console.WriteLine("\nGrouped by Gender:");
        foreach (var group in groupedByGender)
        {
            Console.WriteLine($"\nGender: {group.Key}");
            foreach (var person in group)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

        // 4. Like Clause: Search for a pattern in a string (using Contains, StartsWith, EndsWith)
        var searchByName = people.Where(p => p.FirstName.Contains("an") || p.LastName.Contains("an"));
        Console.WriteLine("\nPeople with 'an' in their first or last name:");
        foreach (var person in searchByName)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}