using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Algorithms
{
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
