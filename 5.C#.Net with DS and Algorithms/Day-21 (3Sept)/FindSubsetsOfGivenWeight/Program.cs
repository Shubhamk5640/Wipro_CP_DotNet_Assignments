using System;
using System.Collections.Generic;

class SubsetSum
{
    public static void FindSubsets(int[] weights, int n, int target)
    {
        List<int> subset = new List<int>();
        FindSubsetsRec(weights, n, subset, 0, target, 0);
    }

    private static void FindSubsetsRec(int[] weights, int n, List<int> subset, int sum, int target, int start)
    {
        // Base Case: If sum equals target, print the subset
        if (sum == target)
        {
            Console.WriteLine(string.Join(", ", subset));
            return;
        }

        // Base Case: If sum exceeds the target or we reach the end
        if (sum > target || start == n)
        {
            return;
        }

        // Include the current element and move to the next element
        subset.Add(weights[start]);
        FindSubsetsRec(weights, n, subset, sum + weights[start], target, start + 1);

        // Exclude the current element and move to the next element
        subset.RemoveAt(subset.Count - 1);
        FindSubsetsRec(weights, n, subset, sum, target, start + 1);
    }

    public static void Main()
    {
        int[] weights = { 5, 10, 12, 13, 15, 18 };
        int target = 30;
        int n = weights.Length;

        Console.WriteLine("Subsets of given weights that sum up to " + target + " are:");
        FindSubsets(weights, n, target);
    }
}