using System;

namespace CustomRandom
{
    public class Randomizer
    {
        public static float GetRandom(float min, float max)
        {
            Random random = new Random();
            float result;

            int var1 = Convert.ToInt32(min * 100);
            int var2 = Convert.ToInt32(max * 100);

            result = random.Next(var1, var2);

            return result / 100;
        }

        public static int GetRandom(int min, int max)
        {
            Random random = new Random();
            int result;

            int var1 = min;
            int var2 = max;

            result = random.Next(var1, var2);

            return result;
        }
    }
}