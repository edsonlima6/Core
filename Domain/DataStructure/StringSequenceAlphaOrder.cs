using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataStructure
{
    public class StringSequenceAlphaOrder
    {
        static int MAX = 26;

        // Function to print the frequency
        // of each of the characters of
        // s in alphabetical order
        // https://www.geeksforgeeks.org/print-the-frequency-of-each-character-in-alphabetical-order/ 
        static void compressString(string s, int n)
        {
            // To store the frequency
            // of the characters
            int[] freq = new int[MAX];

            // Update the frequency array
            for (int i = 0; i < n; i++)
            {
                var num = s[i] - 'a';
                freq[s[i] - 'a']++;
            }

            // Print the frequency in alphatecial order
            for (int i = 0; i < MAX; i++)
            {

                // If the current alphabet doesn't
                // appear in the string
                if (freq[i] == 0)
                    continue;

                Console.Write((char)(i + 'a') + "" + freq[i]);
            }

            var num3 = 4 + 'a';
        }

        // Driver code
        public static void Main()
        {
            string s = "geeksforgeeks";
            int n = s.Length;

            compressString(s, n);
        }
    }
}
