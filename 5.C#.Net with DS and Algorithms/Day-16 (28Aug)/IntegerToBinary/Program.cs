using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter an integer value
        Console.Write("Enter an integer value: ");

        // Read the user input and convert it to an integer
        int number = Convert.ToInt32(Console.ReadLine());

        // Convert the integer to a binary string
        string binaryRepresentation = Convert.ToString(number, 2);

        // Display the result
        Console.WriteLine($"The binary representation of {number} is: {binaryRepresentation}");
    }
}