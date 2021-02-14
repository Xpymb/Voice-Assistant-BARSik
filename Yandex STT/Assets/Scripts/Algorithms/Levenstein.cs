using System;

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
}
