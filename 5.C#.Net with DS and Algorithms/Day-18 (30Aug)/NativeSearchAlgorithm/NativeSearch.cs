using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveSearchAlgorithm
{
    class NativeSearch
    {
        static void NativeStringSearch(string text, string pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;

            for (int i = 0; i <= textLength - patternLength; i++)
            {
                int j;
                for (j = 0; j < patternLength; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }

                if (j == patternLength)
                    Console.WriteLine($"Pattern found at index {i}");
            }
        }

        static void Main()
        {
            string text = "aabcabcabdeabc";
            string pattern = "abc";

            NativeStringSearch(text, pattern);
        }
    }
}
