using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RabinKarpAlgorithm
{
    class RabinKarp
    {
        public static void Search(string text, string pattern)
        {
            int baseVal = 256; 
            int prime = 101;   
            int m = pattern.Length;
            int n = text.Length;
            int patternHash = 0; 
            int textHash = 0;    
            int h = 1;

            for (int i = 0; i < m - 1; i++)
                h = (h * baseVal) % prime;

            for (int i = 0; i < m; i++)
            {
                patternHash = (baseVal * patternHash + pattern[i]) % prime;
                textHash = (baseVal * textHash + text[i]) % prime;
            }

            Console.WriteLine($"Pattern Hash: {patternHash}");

            for (int i = 0; i <= n - m; i++)
            {
                Console.WriteLine($"Text Hash at index {i}: {textHash}");

                if (patternHash == textHash)
                {
                    int j;
                    for (j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    if (j == m)
                        Console.WriteLine($"Pattern found at index {i}");
                }

                if (i < n - m)
                {
                    textHash = (baseVal * (textHash - text[i] * h) + text[i + m]) % prime;

                    if (textHash < 0)
                        textHash = (textHash + prime);
                }
            }
        }

        static void Main()
        {
            string text = "aabcabcabdeabc";
            string pattern = "abc";
            Search(text, pattern);
        }
    }
}
