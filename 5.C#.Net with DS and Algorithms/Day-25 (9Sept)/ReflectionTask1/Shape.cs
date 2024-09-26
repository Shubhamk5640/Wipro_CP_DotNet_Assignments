using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask1
{
    public class Shape : BaseEntity, IMovable, IDrawable
    {
        public Shape(string name) : base(name) { }

        public void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }

        public void Draw()
        {
            Console.WriteLine($"{Name} is being drawn.");
        }
    }
}
