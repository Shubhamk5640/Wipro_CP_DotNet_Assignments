using System;

namespace Merge_Sort_Algorithm
{
    public class MergeSortAlgo
    {
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k++] = L[i++];
                }
                else
                {
                    arr[k++] = R[j++];
                }
            }

            while (i < n1)
            {
                arr[k++] = L[i++];
            }

            while (j < n2)
            {
                arr[k++] = R[j++];
            }
        }

        static void Main()
        {
            int[] arrayInts = { 5, 8, 4, 3, 0, 1, 7, 6, 10, 50, 40, 60, 20 };
            int len = arrayInts.Length;

            Console.WriteLine("Given Array:");
            Console.WriteLine(string.Join(", ", arrayInts));

            MergeSort(arrayInts, 0, len - 1);

            Console.WriteLine("\nAfter Merge Sort:");
            Console.WriteLine(string.Join(", ", arrayInts));
        }
    }
}
