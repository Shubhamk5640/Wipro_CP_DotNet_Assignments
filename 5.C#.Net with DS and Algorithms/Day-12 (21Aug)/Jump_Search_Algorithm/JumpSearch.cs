using System;

namespace Jump_Search_Algorithm
{
    public class JumpSearchAlgo
    {
        static void Main()
        {

            int[] arrayInts = { 0, 1, 3, 4, 5, 6, 7, 8, 10, 20, 40, 50, 60 };

            Console.WriteLine("Given array:");
            foreach (int num in arrayInts)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.Write("\nEnter target element: ");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("\n-----------Using Jump Search----------");


            int index = JumpSearch(arrayInts, target);

            if (index != -1)
            {
                Console.WriteLine("Target element located on index " + index);
            }
            else
            {
                Console.WriteLine("Target element not found in the array.");
            }
        }

        static int JumpSearch(int[] array, int target)
        {
            int length = array.Length;
            int step = (int)Math.Floor(Math.Sqrt(length));
            int prev = 0;


            while (array[Math.Min(step, length) - 1] < target)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(length));
                if (prev >= length)
                    return -1;
            }


            while (array[prev] < target)
            {
                prev++;

                if (prev == Math.Min(step, length))
                    return -1;
            }


            if (array[prev] == target)
                return prev;

            return -1;
        }
    }
}
