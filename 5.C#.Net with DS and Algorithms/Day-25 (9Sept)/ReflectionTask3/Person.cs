using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask3
{
    public class Person : Human, IPersonDetails, IWorkDetails, IHealthDetails
    {
        public string Name { get; set; } // Property 2
        public int Age { get; set; }     // Property 3
        public string JobTitle;          // Field 3

        public Person()
        {
            Name = "Shubham Kumbhar";
            Age = 25;
            JobTitle = "Dot Net Developer";
            Height = 182;
            Weight = 76;
        }

        // Implement the methods from IPersonDetails
        public void ShowPersonDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}");
        }

        // Method with parameters to set details
        public void SetPersonDetails(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"Person details updated: Name = {Name}, Age = {Age}");
        }

        // Implement the methods from IWorkDetails
        public void ShowWorkDetails()
        {
            Console.WriteLine($"Job Title: {JobTitle}");
        }

        // Implement the methods from IHealthDetails
        public void ShowHealthDetails()
        {
            Console.WriteLine($"Height: {Height}, Weight: {Weight}, Is Alive: {IsAlive}");
        }

        // Additional method with parameters for promotion
        public void Promote(string newTitle)
        {
            JobTitle = newTitle;
            Console.WriteLine($"Employee is promoted as {JobTitle}");
        }

        public void Work()
        {
            Console.WriteLine("Employee is working");
        }
    }


}
