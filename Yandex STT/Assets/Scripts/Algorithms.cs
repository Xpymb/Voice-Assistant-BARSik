using System;
using System.Collections.Generic;

/**
* Algorithm's library 
* which includes:
* 1) Levenshtein (measuring the difference between two character sequences);
* 2) KnuttMorrisPratt (find substring with prefix);
* 3)
* 
*/

namespace Algorithms
{
    public class Levenstein //Get Distance between two strings(often use for detect the gramma errors)
    {
        public int GetDistance(string str1, string str2) 
        {
            int diff;
            int[,] m = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= str2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    diff = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }

            return m[str1.Length, str2.Length];
        }

        public string FindSubNGetDistance(string pattern, string text)
        {
            string[] wordsArray = GetArrayOfWords(text);



            return "";
        }

        string[] GetArrayOfWords(string text)
        {
            List<string> listWords = new List<string>();
            int beginIndex = 0;

            for(int i = 0; i < text.Length; i++)
            {
                if(text[i] == ' ' || text[i] == ',')
                {
                    listWords.Add(GetWord(text, beginIndex, i));
                    beginIndex = i + 1;
                }
            }

            return listWords.ToArray();
        }

        string GetWord(string text, int beginIndex, int endIndex)
        {
            string word = "";

            for (int i = beginIndex; i <= endIndex; i++) { word += text[i]; }

            return word;
        }
    }

    public class KnuttMorrisPratt
    {
        int[] GetPrefix(string str)
        {
            int[] result = new int[str.Length];
            result[0] = 0;
            int index = 0;

            for (int i = 1; i < str.Length; i++)
            {
                while (index >= 0 && str[index] != str[i]) { index--; }
                index++;
                result[i] = index;
            }

            return result;
        }

        public int FindSubstring(string pattern, string text)
        {
            int[] pf = GetPrefix(pattern);
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (index > 0 && pattern[index] != text[i]) { index = pf[index - 1]; }
                if (pattern[index] == text[i]) index++;
                if (index == pattern.Length)
                {
                    return i - index + 1;
                }
            }

            return -1;
        }
    }
}