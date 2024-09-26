using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask1
{
    public class Car : BaseEntity, IMovable
    {
        public Car(string name) : base(name) { }

        public void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }
    }
}
