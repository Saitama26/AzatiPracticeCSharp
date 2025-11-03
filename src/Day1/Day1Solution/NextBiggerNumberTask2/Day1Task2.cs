using System;

namespace Day1Solution
{
    public class Day1Task2
    {
        public static int? NextBiggerThan(int number)
        {
            if (number < 0) throw new ArgumentException("Number can't be negative");
            char[] chars = number.ToString().ToCharArray();

            int i = chars.Length - 2;
            int j = chars.Length - 1;
            while (i >= 0)
            {
                if (chars[i] < chars[i + 1])
                {
                    while (j > i)
                    {
                        if (chars[i] < chars[j])
                        {
                            (chars[i], chars[j]) = (chars[j], chars[i]);
                            Array.Reverse(chars, i + 1, chars.Length - (i + 1));
                            return int.TryParse(chars, out int n) ? n : null;
                        }

                        j--;
                    }
                }

                i--;
            }
            return null;
        }
    }
}