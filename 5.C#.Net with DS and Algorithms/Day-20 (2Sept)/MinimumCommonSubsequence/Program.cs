using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_common_Subsequence
{

    internal class Program
    {
        static void Main()
        {

            string A = "aabcdefghij";
            string B = "ecdgi";


            int minLength = int.MaxValue;
            int startIndex = -1;


            for (int i = 0; i <= A.Length - B.Length; i++)
            {
                if (A[i] == B[0])
                {
                    int k = i;
                    int j = 0;

                    while (k < A.Length && j < B.Length)
                    {
                        if (A[k] == B[j])
                        {
                            j++;
                        }
                        k++;
                    }


                    if (j == B.Length)
                    {
                        int subsequenceLength = k - i;
                        if (subsequenceLength < minLength)
                        {
                            minLength = subsequenceLength;
                            startIndex = i;
                        }
                    }
                }
            }


            if (startIndex != -1)
            {
                string minSubsequence = A.Substring(startIndex, minLength);
                Console.WriteLine("The Minimum Subsequence is: " + minSubsequence);


                Console.WriteLine("Characters in the Minimum Subsequence: " + string.Join(", ", minSubsequence.ToCharArray()));
            }
            else
            {
                Console.WriteLine("No valid subsequence found.");
            }

            Console.ReadLine();
        }
    }

}
