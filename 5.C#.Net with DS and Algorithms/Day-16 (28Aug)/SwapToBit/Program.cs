using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter the position of the first bit to swap: ");
        int pos1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the position of the second bit to swap: ");
        int pos2 = int.Parse(Console.ReadLine());

        
        Console.WriteLine($"Original number: {number} (Binary: {GetBinaryString(number)})");

        // Swap the bits at position pos1 and pos2
        int result = SwapBits(number, pos1, pos2);

        
        Console.WriteLine($"Number after swapping bits at positions {pos1} and {pos2}: {result} (Binary: {GetBinaryString(result)})");
    }

    static int SwapBits(int number, int pos1, int pos2)
    {
        // Check if the positions are the same
        if (pos1 == pos2)
            return number;

        // Extract the bits at position pos1 and pos2
        int bit1 = (number >> pos1) & 1;
        int bit2 = (number >> pos2) & 1;

        // If the bits are different, swap them
        if (bit1 != bit2)
        {
            // Toggle the bits at pos1 and pos2
            number ^= (1 << pos1);
            number ^= (1 << pos2);
        }

        return number;
    }

    static string GetBinaryString(int number)
    {
        string binary = Convert.ToString(number, 2);
        return string.IsNullOrEmpty(binary) ? "0" : binary;
    }
}