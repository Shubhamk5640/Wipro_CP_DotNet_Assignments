using System;

namespace DelegateExample
{
    // Declare a delegate type
    public delegate void PrintDelegate(string message);

    class Program
    {
        // A method that matches the delegate signature (void, string parameter)
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Another method that matches the delegate signature
        public static void PrintUpperCaseMessage(string message)
        {
            Console.WriteLine(message.ToUpper());
        }

        static void Main(string[] args)
        {
            // Instantiate the delegate and assign the method reference
            PrintDelegate printDelegate = PrintMessage;

            // Invoke the delegate (calls PrintMessage method)
            printDelegate("Hello from delegate!");

            // Reassign the delegate to another method
            printDelegate = PrintUpperCaseMessage;

            // Invoke the delegate (calls PrintUpperCaseMessage method)
            printDelegate("Hello again!");

            Console.ReadLine(); // To keep the console window open
        }
    }
}
