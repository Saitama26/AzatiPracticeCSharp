namespace Day5.Task3;

public static partial class Algorithm
{
    public static bool ValidateBrackets(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException($"{nameof(value)} can't be null");
        }

        var stack = new Stack<char>();

        foreach (var letter in value)
        {
            if (letter == '(' || letter == '{' || letter == '[')
            {
                stack.Push(letter);
            }
            else if (letter == ')' || letter == '}' || letter == ']')
            {
                if (stack.Count == 0) return false;

                var open = stack.Pop();

                if ((open == '(' && letter != ')') ||
                    (open == '{' && letter != '}') ||
                    (open == '[' && letter != ']'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}