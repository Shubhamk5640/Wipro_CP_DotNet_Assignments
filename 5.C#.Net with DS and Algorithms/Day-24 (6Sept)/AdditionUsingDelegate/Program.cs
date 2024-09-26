using System;

namespace DelegateSumExample
{
    // Declare a delegate type that takes two integers and returns an integer
    public delegate int SumDelegate(int a, int b);

    class Program
    {
        // Method that matches the delegate signature
        public static int Add(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            // Instantiate the delegate and assign the Add method to it
            SumDelegate sumDelegate = Add;

            // Use the delegate to calculate the sum
            int result = sumDelegate(10, 20);

            // Print the result
            Console.WriteLine($"The sum of 10 and 20 is: {result}");
            Console.WriteLine("This is done using delegate....");

            Console.ReadLine(); // To keep the console window open
        }
    }
}
