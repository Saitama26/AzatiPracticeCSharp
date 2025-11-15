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
    /// Converts a <see cref="double"/> number into its word-based eng-rus-representation.
    /// </summary>
    /// <param name="number">The number to be transformed.</param>
    /// <param name="language"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the number is <see cref="double.NaN"/> or <see cref="double.PositiveInfinity"/> /
    /// <see cref="double.NegativeInfinity"/>, or when the number contains unsupported characters.
    /// Also when <see cref="string"/> is null or empty, or when the language is not supported.;
    /// </exception>
    public static string TransformToWords(double number, string language)
    {
        if (double.IsNaN(number))
        {
            throw new ArgumentException($"{nameof(number)} can't ba NaN");
        }

        if (double.IsInfinity(number))
        {
            throw new ArgumentException($"{nameof(number)} can't be infinity");
        }

        if (string.IsNullOrEmpty(language))
        {
            throw new ArgumentException($"{nameof(language)} can't be empty");
        }

        var strFormat = number.ToString();
        StringBuilder resultStr = new();

        switch (language)
        {
            case "rus":
                foreach (char c in strFormat)
                {
                    if (NumberWordsRussian.ContainsKey(c))
                        resultStr.Append(NumberWordsRussian[c] + " ");
                }
                break;

            case "eng":
                foreach (char c in strFormat)
                {
                    if (NumberWordsEnglish.ContainsKey(c))
                        resultStr.Append(NumberWordsEnglish[c] + " ");
                }
                break;
            default:
                throw new ArgumentException($"{nameof(language)}. Unknown language");
        }

        return resultStr.ToString().TrimEnd();
    }
}