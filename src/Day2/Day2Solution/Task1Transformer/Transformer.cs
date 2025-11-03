using System.Text;

namespace Day2Solution.Task1Transformer
{
    public class Transformer
    {
        static readonly Dictionary<char, string> numberWords = new Dictionary<char, string>
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
            { 'e', "E" }
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
        public static string TransformToWords(double number)
        {
            if (double.IsNaN(number)) throw new ArgumentException("Number can't ba NaN");
            if (double.IsInfinity(number)) throw new ArgumentException("Number can't be infinity");

            string strFormat = number.ToString();
            StringBuilder resultStr = new();

            foreach (char c in strFormat)
            {
                if (numberWords.ContainsKey(c))
                    resultStr.Append(numberWords[c] + " ");
            }

            return resultStr.ToString().TrimEnd();
        }
    }
}
