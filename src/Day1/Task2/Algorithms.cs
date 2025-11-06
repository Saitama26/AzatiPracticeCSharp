namespace Day1.Task1_2;

public static partial class Algorithms
{
    /// <summary>
    /// Finds the next greater integer that can be formed by rearranging 
    /// the digits of the specified non-negative number.
    /// </summary>
    /// <param name="number">
    /// A non-negative integer whose digits will be rearranged to search for the next greater permutation.
    /// </param>
    /// <returns>
    /// The next greater integer composed of the same digits as <paramref name="number"/> 
    /// if such a number exists; otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="number"/> is negative.
    /// </exception>
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