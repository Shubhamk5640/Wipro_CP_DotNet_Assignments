using System;

class OptimalBinarySearchTree
{
    // Function to calculate the sum of frequencies from i to j
    static int Sum(int[] freq, int i, int j)
    {
        int sum = 0;
        for (int k = i; k <= j; k++)
        {
            sum += freq[k];
        }
        return sum;
    }

    // Function to construct an Optimal Binary Search Tree
    static int OptimalBST(int[] keys, int[] freq, int n)
    {
        // Cost[i][j] will store the cost of Optimal BST that can be constructed from keys[i] to keys[j].
        int[,] cost = new int[n, n];

        // A single key tree will have the cost equal to its frequency.
        for (int i = 0; i < n; i++)
        {
            cost[i, i] = freq[i];
        }

        // L is the chain length.
        for (int L = 2; L <= n; L++)
        {
            for (int i = 0; i <= n - L; i++) // Corrected loop condition
            {
                int j = i + L - 1;
                cost[i, j] = int.MaxValue;

                // Try making all keys in interval keys[i..j] as the root
                for (int r = i; r <= j; r++)
                {
                    // c = cost when keys[r] becomes the root of this subtree
                    int c = ((r > i) ? cost[i, r - 1] : 0) +
                            ((r < j) ? cost[r + 1, j] : 0) +
                            Sum(freq, i, j);

                    // Update cost if current arrangement is more efficient
                    if (c < cost[i, j])
                    {
                        cost[i, j] = c;
                    }
                }
            }
        }

        // The result is the minimum cost of the whole sequence from 0 to n-1
        return cost[0, n - 1];
    }

    static void Main()
    {
        int[] keys = { 10, 20, 30, 40 };
        int[] freq = { 4, 2, 6, 3 };
        int n = keys.Length;

        // Printing keys and frequencies in one line each
        Console.WriteLine("Keys: " + string.Join(", ", keys));
        Console.WriteLine("Frequencies: " + string.Join(", ", freq));

        int minCost = OptimalBST(keys, freq, n);
        Console.WriteLine($"\nThe minimum cost of the Optimal Binary Search Tree is: {minCost}");
    }
}