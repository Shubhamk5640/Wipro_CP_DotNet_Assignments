using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP_Algorithm
{
    class KMPAlgorithm
    {
        private static int[] ComputePiTable(string pattern)
        {
            int length = pattern.Length;
            int[] pi = new int[length];
            int len = 0; 
            int i = 1;

            pi[0] = 0; 

            while (i < length)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    pi[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = pi[len - 1];
                    }
                    else
                    {
                        pi[i] = 0;
                        i++;
                    }
                }
            }

            return pi;
        }

        
        public static void KMPSearch(string text, string pattern)
        {
            int m = pattern.Length;
            int n = text.Length;

            int[] pi = ComputePiTable(pattern);

            int i = 0; 
            int j = 0; 

            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if (j == m)
                {
                    Console.WriteLine("Pattern found at index " + (i - j));
                    j = pi[j - 1];
                }
                else if (i < n && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = pi[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Pattern found with KMP Algorithm : ");
            string text = "aabcabcabdeabc";
            string pattern = "abc";

            KMPSearch(text, pattern);
        }
    }
}
