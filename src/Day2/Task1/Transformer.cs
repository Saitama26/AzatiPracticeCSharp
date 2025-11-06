using System.Text;

namespace Day2.Task1_2;

public static partial class Transformer
{
    private static readonly Dictionary<char, string> NumberWordsEnglish = new Dictionary<char, string>
        {
            { '0', "zero" },
            { '1', "one" },
            { '2', "two" },
            { '3', "three" },
            { '4', "four" },
            { '5', "five" },
            { '6', "six" },
            { '7', "seven" },
            { '8', "eight" },
            { '9', "nine" },
            { '-', "minus" },
            { '.', "point" },
            { ',', "point" },
            { 'e', "E" },
            { 'E', "E" }
        };

    private static readonly Dictionary<char, string> NumberWordsRussian = new Dictionary<char, string>
        {
            { '0', "ноль" },
            { '1', "один" },
            { '2', "два" },
            { '3', "три" },
            { '4', "четыре" },
            { '5', "пять" },
            { '6', "шесть" },
            { '7', "семь" },
            { '8', "восемь" },
            { '9', "девять" },
            { '-', "минус" },
            { '.', "точка" },
            { ',', "точка" },
            { 'e', "E" },
            { 'E', "E" }
        };


    /// <summary>
    /// Converts a <see cref="double"/> number into its word-based representation.
    /// For example: -23.809 → "minus two three point eight zero nine".
    /// </summary>
    /// <param name="number">The number to be transformed.</param>
    /// <returns>
    /// A string containing the word representation of the number.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the number is <see cref="double.NaN"/> or <see cref="double.PositiveInfinity"/> /
    /// <see cref="double.NegativeInfinity"/>, or when the number contains unsupported characters.
    /// </exception>
    public static string TransformToWordsEng(double number)
    {
        if (double.IsNaN(number)) throw new ArgumentException("Number can't ba NaN");
        if (double.IsInfinity(number)) throw new ArgumentException("Number can't be infinity");

        string strFormat = number.ToString();
        StringBuilder resultStr = new();

        foreach (char c in strFormat)
        {
            if (NumberWordsEnglish.ContainsKey(c))
                resultStr.Append(NumberWordsEnglish[c] + " ");
        }

        return resultStr.ToString().TrimEnd();
    }

    public static string TransformToWordsRus(double number)
    {
        if (double.IsNaN(number)) throw new ArgumentException("Number can't ba NaN");
        if (double.IsInfinity(number)) throw new ArgumentException("Number can't be infinity");

        string strFormat = number.ToString();
        StringBuilder resultStr = new();

        foreach (char c in strFormat)
        {
            if (NumberWordsRussian.ContainsKey(c))
                resultStr.Append(NumberWordsRussian[c] + " ");
        }

        return resultStr.ToString().TrimEnd();
    }
}
