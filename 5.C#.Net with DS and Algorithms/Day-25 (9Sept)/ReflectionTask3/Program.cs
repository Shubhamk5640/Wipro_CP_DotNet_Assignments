using ReflectionTask3;
using System.Reflection;
using System;

namespace ReflectionTask3
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the fully qualified type name (Namespace.TypeName) to inspect: ");
            string typeName = Console.ReadLine();

            Assembly assembly = Assembly.GetExecutingAssembly();


            Type typeToInspect = assembly.GetType(typeName);

            if (typeToInspect == null)
            {
                Console.WriteLine("Type not found. Please make sure you enter the full name, including the namespace.");
                return;
            }

            Console.WriteLine($"\nType: {typeToInspect.Name}");
            Console.WriteLine($"Base Type: {typeToInspect.BaseType?.Name}");


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



            MethodInfo[] methods = typeToInspect.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                Console.WriteLine($"\nMethod: {method.Name}");
                ParameterInfo[] parameters = method.GetParameters();
                Console.WriteLine($"No of Parameters: {parameters.Length}");


                if (parameters.Length == 0)
                {

                    method.Invoke(instance, null);
                }
                else if (method.Name == "Promote")
                {

                    object[] paramValues = { "Senior Developer" };
                    method.Invoke(instance, paramValues);
                }



            }
            Console.ReadLine();
        }
    }

}
