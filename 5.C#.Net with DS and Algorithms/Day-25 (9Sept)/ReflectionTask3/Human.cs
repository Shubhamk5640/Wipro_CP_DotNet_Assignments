using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask3
{
    public class Human
    {
        public bool IsAlive = true;
        public int Height; // Field 1
        public int Weight; // Field 2

        public string Species { get; set; } = "Homo Sapiens"; // Property 1
    }


}
