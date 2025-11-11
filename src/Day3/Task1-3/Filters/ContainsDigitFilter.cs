using Day3.Task1_3.Interfaces;
namespace Day3.Task1_3.Filters;

public class ContainsDigitFilter : IPredicate<int>
{
    private readonly int _digit;

    public ContainsDigitFilter(int digit)
    {
        if (digit < 0 || digit > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(digit), "Цифра должна быть от 0 до 9");
        }

        _digit = digit;
    }

    public bool IsMatched(int element)
    {
        var number = element.ToString();

        return number.Contains(_digit.ToString());
    }
}