using System;

class Program
{
    static void Main()
    {
        int[] arr = { 4, 1, 2, 1, 2, 4, 5, 6 };
        var result = FindTwoNonRepeatingElements(arr);
        Console.WriteLine("The two non-repeating elements are: " + result.Item1 + " and " + result.Item2);
    }

    static Tuple<int, int> FindTwoNonRepeatingElements(int[] arr)
    {
        int xorResult = 0;

        // Step 1: XOR all elements in the array
        foreach (int num in arr)
        {
            xorResult ^= num;
        }

        // Step 2: Find a bit that is set in xorResult (rightmost set bit)
        int setBit = xorResult & ~(xorResult - 1);

        int x = 0, y = 0;

        // Step 3: Divide elements into two groups and XOR separately
        foreach (int num in arr)
        {
            if ((num & setBit) != 0)
            {
                x ^= num;
            }
            else
            {
                y ^= num;
            }
        }

        // Step 4: x and y are the two unique numbers
        return new Tuple<int, int>(x, y);
    }
}