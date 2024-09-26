using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to input the type to inspect
            Console.Write("Enter the fully qualified type name (Namespace.TypeName) to inspect: ");
            string typeName = Console.ReadLine();

            // Load the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get the specified type by name
            Type typeToInspect = assembly.GetType(typeName);

            // Check if the type exists
            if (typeToInspect == null)
            {
                Console.WriteLine("Type not found. Please make sure you enter the full name, including the namespace.");
                return;
            }

            // Print the type name and its base type
            Console.WriteLine($"\nType: {typeToInspect.Name}");
            Console.WriteLine($"Base Type: {typeToInspect.BaseType?.Name}");

            // Print implemented interfaces
            Type[] implementedInterfaces = typeToInspect.GetInterfaces();
            if (implementedInterfaces.Length > 0)
            {
                Console.WriteLine("Interfaces: ");
                foreach (Type iface in implementedInterfaces)
                {
                    Console.WriteLine($"  - {iface.Name}");
                }
            }
            else
            {
                Console.WriteLine("No Interfaces Implemented");
            }

            // Try to create an instance of the specified type
            object instance = null;
            try
            {
                instance = Activator.CreateInstance(typeToInspect);
                Console.WriteLine("\nInstance created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnable to create instance: {ex.Message}. Proceeding with inspection of type members.");
            }

            // Print all public properties
            Console.WriteLine("\nPublic Properties:");
            PropertyInfo[] properties = typeToInspect.GetProperties();
            foreach (var property in properties)
            {
                if (instance != null)
                {
                    Console.WriteLine($"- {property.Name} ({property.PropertyType.Name}) = {property.GetValue(instance)}");
                }
                else
                {
                    Console.WriteLine($"- {property.Name} ({property.PropertyType.Name})");
                }
            }

            // Print all public fields
            Console.WriteLine("\nPublic Fields:");
            FieldInfo[] fields = typeToInspect.GetFields();
            foreach (var field in fields)
            {
                if (instance != null)
                {
                    Console.WriteLine($"- {field.Name} ({field.FieldType.Name}) = {field.GetValue(instance)}");
                }
                else
                {
                    Console.WriteLine($"- {field.Name} ({field.FieldType.Name})");
                }
            }

            // Invoke methods from implemented interfaces, if applicable
            if (instance is IPersonDetails personDetails)
            {
                Console.WriteLine("\nCalling ShowPersonDetails method from IPersonDetails:");
                personDetails.ShowPersonDetails();
            }

            if (instance is IWorkDetails workDetails)
            {
                Console.WriteLine("\nCalling ShowWorkDetails method from IWorkDetails:");
                workDetails.ShowWorkDetails();
            }

            if (instance is IHealthDetails healthDetails)
            {
                Console.WriteLine("\nCalling ShowHealthDetails method from IHealthDetails:");
                healthDetails.ShowHealthDetails();
            }

            // Prevent the console from closing immediately
            Console.ReadLine();
        }
    }
}