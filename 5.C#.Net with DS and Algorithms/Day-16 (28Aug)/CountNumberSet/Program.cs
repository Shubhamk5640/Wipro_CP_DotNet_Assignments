using System;

class Program
{
    static void Main()
    {
        // Input integer value
        // Prompt the user to enter an integer value
        Console.Write("Enter an integer value: ");

        // Read the user input and convert it to an integer
        int number = Convert.ToInt32(Console.ReadLine());

        // Call the function to count the number of set bits
        int setBitCount = CountSetBits(number);

        // Display the result
        Console.WriteLine($"The number of set bits in {number} is: {setBitCount}");
    }

    // Function to count the number of set bits
    static int CountSetBits(int n)
    {
        int count = 0;

        while (n > 0)
        {
            // Check if the least significant bit is set
            count += n & 1;

            // Right shift the bits of n by 1
            n >>= 1;
        }

        return count;
    }
}