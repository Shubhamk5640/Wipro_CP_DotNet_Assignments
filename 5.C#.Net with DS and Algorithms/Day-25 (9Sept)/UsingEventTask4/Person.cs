using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEventTask4
{
    public class Person : Human, IPersonDetails, IWorkDetails, IHealthDetails
    {
        // Declare the delegate for the event
        public delegate void PromotedEventHandler(object source, EventArgs args);

        // Declare the event based on the delegate
        public event PromotedEventHandler Promoted;

        public string Name { get; set; } // Property 2
        public int Age { get; set; }     // Property 3
        public string JobTitle;          // Field 3

        public Person()
        {
            Name = "John Doe";
            Age = 30;
            JobTitle = "Software Engineer";
            Height = 180;
            Weight = 75;
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

        // Method to trigger the event
        protected virtual void OnPromoted()
        {
            if (Promoted != null)
            {
                Promoted(this, EventArgs.Empty);  // Trigger the event
            }
        }

        // Additional method with parameters for promotion
        public void Promote(string newTitle)
        {
            JobTitle = newTitle;
            Console.WriteLine($"Employee is promoted as {JobTitle}");

            // Raise the event
            OnPromoted();
        }

        public void Work()
        {
            Console.WriteLine("Employee is working");
        }

    }

}
