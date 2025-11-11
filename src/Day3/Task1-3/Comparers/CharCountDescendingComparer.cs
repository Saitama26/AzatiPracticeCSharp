namespace Day3.Task1_3.Comparers;
public class CharCountDescendingComparer : IComparer<string>
{
    private readonly char _symbol;

    public CharCountDescendingComparer(char symbol)
    {
        _symbol = symbol;
    }

    public int Compare(string? x, string? y)
    {
        int countX = x?.Count(c => c == _symbol) ?? 0;
        int countY = y?.Count(c => c == _symbol) ?? 0;
        return countY.CompareTo(countX);
    }
}