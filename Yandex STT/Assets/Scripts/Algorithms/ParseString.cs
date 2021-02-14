using System;
using System.Collections.Generic;

namespace Algorithms
{
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
                foreach (string pattern in patterns)
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
                if (text[i] == ' ' || text[i] == ',' || i == text.Length - 1)
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
}