using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask2
{
    public class Car : BaseEntity, IPersonDetails, IWorkDetails
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car()
        {
            Name = "Default Car";
            Model = "Sedan";
            Year = 2022;
        }

        public Car(string name, string model, int year)
        {
            Name = name;
            Model = model;
            Year = year;
        }

        public void ShowPersonDetails()
        {
            Console.WriteLine($"Car Name: {Name}, Person: Driving");
        }

        public void ShowWorkDetails()
        {
            Console.WriteLine($"Car Name: {Name}, Work: Transporting");
        }
    }
}