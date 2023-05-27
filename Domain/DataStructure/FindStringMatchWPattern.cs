using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataStructure
{
    //public class FindStringMatchWPattern
    //{
    //}
    //Find all strings that match specific pattern in a dictionary
    // https://www.geeksforgeeks.org/find-all-strings-that-match-specific-pattern-in-a-dictionary/
    public class FindStringMatchWPattern
    {
        /* Given a dictionary of words, find all strings that match the given pattern where every character in the pattern is uniquely mapped to a character in the dictionary.
         * Input:  
             dict = ["abb", "abc", "xyz", "xyy"];
             pattern = "foo"
             Output: [xyy abb]
             xyy and abb have same character at 
             index 1 and 2 like the pattern

             Input: 
             dict = ["abb", "abc", "xyz", "xyy"];
             pat = "mno"
             Output: [abc xyz]
             abc and xyz have all distinct characters,
             similar to the pattern.

             Input:  
             dict = ["abb", "abc", "xyz", "xyy"];
             pattern = "aba"
             Output: [] 
             Pattern has same character at index 0 and 2. 
             No word in dictionary follows the pattern.

             Input:  
             dict = ["abab", "aba", "xyz", "xyx"];
             pattern = "aba"
             Output: [aba xyx]
             aba and xyx have same character at 
             index 0 and 2 like the pattern

        Method 1:

        Approach: 
        The aim is to find whether the word has the same structure as the pattern. 
        An approach to this problem can be to make a hash of the word and pattern and compare if they are equal or not. In simple language, 
        we assign different integers to the distinct characters of the word and make a string of integers (hash of the word) 
        according to the occurrence of a particular character in that word and then compare it with the hash of the pattern.

        Example
        Word='xxyzzaabcdd'
        Pattern='mmnoopplfmm'
        For word-:
        map['x']=1;
        map['y']=2;
        map['z']=3;
        map['a']=4;
        map['b']=5;
        map['c']=6;
        map['d']=7;
        Hash for Word="11233445677"

        For Pattern-:
        map['m']=1;
        map['n']=2;
        map['o']=3;
        map['p']=4;
        map['l']=5;
        map['f']=6;
        Hash for Pattern="11233445611"
        Therefore in the given example Hash of word 
        is not equal to Hash of pattern so this word 
        is not included in the answer
         */

        String[] dict { get; set; }
        String pattern { get; set; }
        public FindStringMatchWPattern()
        {
            dict = new String[] { "abb", "abc", "xyz", "xyy", "cdd" };
            pattern = "foo";
        }

        public void findMatchedWords()
        {
            ///findMatchedWords(dict, pattern);
            string hashCode = GetHashCode(pattern);
            for (int i = 0; i < dict.Length; i++)
            {
                if (dict[i].Length == pattern.Length && GetHashCode(dict[i]).Equals(hashCode))
                    Console.WriteLine(dict[i] + " -> ");
            }

        }

        private string GetHashCode(string letter)
        {
            string hs = string.Empty;
            var dicAlphabetic = new Dictionary<char, int>();
            int j = 0;
            for (int i = 0; i < letter.Length; i++)
            {
                if (!dicAlphabetic.ContainsKey(letter[i]))
                    dicAlphabetic.Add(letter[i], j++);

                hs += dicAlphabetic[letter[i]];
            }


            return hs;
        }

        static String encodeString(String str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            String res = "";
            int i = 0;

            // for each character in given string
            char ch;
            for (int j = 0; j < str.Length; j++)
            {
                ch = str[j];

                // If the character is occurring for the first
                // time, assign next unique number to that char
                if (!map.ContainsKey(ch))
                    map.Add(ch, i++);

                // append the number associated with current
                // character into the output string
                res += map[ch];
            }

            return res;
        }

        // Function to print all the
        // strings that match the
        // given pattern where every
        // character in the pattern is
        // uniquely mapped to a character
        // in the dictionary
        static void findMatchedWords(String[] dict, String pattern)
        {
            // len is length of the pattern
            int len = pattern.Length;

            // encode the string
            String hash = encodeString(pattern);

            // for each word in the dictionary array
            foreach (String word in dict)
            {
                // If size of pattern is same as
                // size of current dictionary word
                // and both pattern and the word
                // has same hash, print the word
                if (word.Length == len && encodeString(word).Equals(hash))
                    Console.Write(word + " ");
            }
        }
    }
}
