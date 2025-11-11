using Day3.Task1_3.Interfaces;
namespace Day3.Task1_3.Filters;

public class EvenNumberFilter : IPredicate<int>
{
    public bool IsMatched(int element)
    {
        return element % 2 == 0;
    }
}
