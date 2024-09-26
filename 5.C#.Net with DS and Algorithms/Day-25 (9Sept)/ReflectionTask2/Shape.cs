using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask2
{
    public class Shape : BaseEntity, IHealthDetails
    {
        public string ShapeName { get; set; }
        public string Material { get; set; }
        public int Dimension { get; set; }

        public Shape()
        {
            ShapeName = "Circle";
            Material = "Steel";
            Dimension = 3;
        }

        public Shape(string shapeName, string material, int dimension)
        {
            ShapeName = shapeName;
            Material = material;
            Dimension = dimension;
        }

        public void ShowHealthDetails()
        {
            Console.WriteLine($"Shape Name: {ShapeName}, Health: Strong Structure");
        }
    }
}