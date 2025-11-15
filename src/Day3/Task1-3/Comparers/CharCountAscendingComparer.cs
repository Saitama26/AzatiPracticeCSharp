namespace Day3.Task1_3.Comparers;

public class CharCountAscendingComparer : IComparer<string>
{
    private readonly char _symbol;

    public CharCountAscendingComparer(char symbol)
    {
        _symbol = symbol;
    }

    public int Compare(string? x, string? y)
    {
        int countX = x?.Count(c => c == _symbol) ?? 0;
        int countY = y?.Count(c => c == _symbol) ?? 0;

        return countX.CompareTo(countY);
    }
}