using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort_Algorithm
{
    public class BubbleSortAlgo
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                // Track if any swap happens
                bool swapped = false;

                // Perform a single pass and move the largest element to the end
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap arr[j] and arr[j + 1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                // If no two elements were swapped in the inner loop, then the array is sorted
                if (!swapped)
                    break;
            }
        }

        static void Main()
        {
            int[] arrayInts = { 5, 8, 4, 3, 0, 1, 7, 6, 10, 50, 40, 60, 20 };

            Console.WriteLine("Before Bubble Sort:");
            Console.WriteLine(string.Join(", ", arrayInts));

            BubbleSort(arrayInts);

            Console.WriteLine("\nAfter Bubble Sort:");
            Console.WriteLine(string.Join(", ", arrayInts));
        }
    }
}
