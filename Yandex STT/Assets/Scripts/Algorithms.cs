using System;
using System.Collections.Generic;

/**
* Algorithms library 
* which includes:
* 
* 1) Levenshtein (measuring the difference between two character sequences)
* 
*    1. Levenshtein.GetDistance(string, string) 
*    
*       return: <int> distance between two character sequences 
*       description: Classic algorithm
*       
* 2) ParseString (parsing string)
* 
*    1. ParseString.FindSubstring(pattern, text)
*    
*       return: <string> found patern in text
*       
*    2. ParseString.FindSubstring(patterns[], text)
*    
*       return: <string> found patern from patters array in text
* 
* 3) KnuttMorrisPratt (find substring with prefix)
* 
*/

namespace Algorithms
{
    public class Levenstein //Get Distance between two strings(often use for detect the gramma errors)
    {
        public int GetDistance(string str1, string str2) //Classic algorithm Levenshtein.GetDistance(string, string) return: int distance between two character sequences
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
    }

    public class ParseString
    {
        public string FindSubstring(string pattern, string text)
        {
            string[] wordsArray = GetArrayOfWords(text);
            string foundWord = "";

            foreach (string word in wordsArray)
            {
                if (pattern[0] == word[0])
                {
                     if (IsSequenceSame(pattern, word))
                     {
                        foundWord = pattern;
                        break;
                     }
                }
             }

            return foundWord;
        }

        public string FindSubstring(string[] patterns, string text)
        {
            string[] wordsArray = GetArrayOfWords(text);
            string foundWord = "";

            foreach (string word in wordsArray)
            {
                foreach(string pattern in patterns)
                {
                    if (pattern[0] == word[0])
                    {
                        if (IsSequenceSame(pattern, word))
                        {
                            foundWord = pattern;
                            break;
                        }
                    }
                }
            }

            return foundWord;
        }

        string[] GetArrayOfWords(string text)
        {
            List<string> listWords = new List<string>();
            int beginIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] == ' ' || text[i] == ',' || i == text.Length - 1)
                {
                    string word = GetWord(text, beginIndex, i - 1);

                    listWords.Add(word);
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

        bool IsSequenceSame(string str1, string str2)
        {
            int len = Math.Min(str1.Length, str2.Length);

            for (int i = 0; i < len; i++)
            {
                if (str1[i] == str2[i]) { continue; }
                else { return false; }
            }

            return true;
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