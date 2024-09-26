using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Types in the Assembly:");
            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"\nType: {type.Name}");

                Console.WriteLine($"Base Type: {type.BaseType?.Name}");

                Type[] interfaces = type.GetInterfaces();
                if (interfaces.Length > 0)
                {
                    Console.WriteLine(" Implemented Interfaces: ");
                    foreach (var iface in interfaces)
                    {
                        Console.WriteLine($"   - {iface.Name}");
                    }
                }
                else
                {
                    Console.WriteLine(" No Interfaces Implemented");
                }
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
