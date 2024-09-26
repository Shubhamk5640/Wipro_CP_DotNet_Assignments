using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching_Algorithms_Assignment
{
    public class LinearSearchAlgo
    {
        static void Main()
        {
            int[] arrayInts = { 5, 8, 4, 3, 0, 1, 7, 6, 10, 50, 40, 60, 20 };

            Console.WriteLine("Given array:");
            foreach (int num in arrayInts)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.Write("\nEnter target element: ");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("\n-----------Using Linear Search----------");

            int index = LinearSearch(arrayInts, target);

            if (index != -1)
            {
                Console.WriteLine("Target element located on index " + index);
            }
            else
            {
                Console.WriteLine("Target element not found in the array.");
            }
        }

        static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }


    }
}

