using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSProblem
{
    internal class LCS
    {
        static void Main()
        {
            string A = "aabcdefghij";
            string B = "ecdgi";

            int m = A.Length;
            int n = B.Length;

            int[,] L = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i, j] = 0;
                    }
                    else if (A[i - 1] == B[j - 1])
                    {
                        L[i, j] = L[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                    }
                }
            }

            Console.WriteLine("Length of LCS is: " + L[m, n]);

            int index = L[m, n];
            char[] lcs = new char[index];

            int iIndex = m, jIndex = n;
            while (iIndex > 0 && jIndex > 0)
            {
                if (A[iIndex - 1] == B[jIndex - 1])
                {
                    lcs[index - 1] = A[iIndex - 1];
                    iIndex--;
                    jIndex--;
                    index--;
                }
                else if (L[iIndex - 1, jIndex] > L[iIndex, jIndex - 1])
                {
                    iIndex--;
                }
                else
                {
                    jIndex--;
                }
            }

            Console.Write("Longest Common Subsequence is: ");
            foreach (var c in lcs)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}
