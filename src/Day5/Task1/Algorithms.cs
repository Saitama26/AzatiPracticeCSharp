namespace Day5.Task1;

public static partial class Algorithms
{
    public static IEnumerable<int> ParseString(IEnumerable<string> inputs, int numberDegree)
    {
        if (inputs == null)
        {
            throw new ArgumentNullException($"{nameof(inputs)} can't be null");
        } 
        if (numberDegree < 2 || numberDegree > 16)
        {
            throw new ArgumentOutOfRangeException($"{nameof(numberDegree)} is out of range");
        }

        var results = new List<int>();

        foreach (var input in inputs)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)} can't be empty");
            }

            var str = input.Trim();
            var negative = str.StartsWith("-");
            
            if (negative)
            {
                str = str.Substring(1);
            }

            var value = 0;

            for (var index = 0; index < str.Length; index++) 
            {
                var digit = CharToDigit(str[index]);
                if(digit > numberDegree)
                {
                    throw new ArgumentException($"{nameof(numberDegree)}  is unacceptable for the numeral system. Number degree is {numberDegree}");
                }

                checked
                {
                    value += digit * (int)Math.Pow(numberDegree, str.Length - 1 - index);
                }
            }
            if (negative) 
            { 
                value = -value; 
            }

            results.Add(value);
        }

        return results;
    }

    private static int CharToDigit(char c)
    {
        if (c >= '0' && c <= '9')
            return c - '0';
        if (c >= 'A' && c <= 'F')
            return 10 + (c - 'A');
        if (c >= 'a' && c <= 'f')
            return 10 + (c - 'a');

        throw new ArgumentException($"invalid character '{nameof(c)}' in a number.");
    }
}