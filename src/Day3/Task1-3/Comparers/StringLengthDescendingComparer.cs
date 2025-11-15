namespace Day3.Task1_3.Comparers;

public class StringLengthDescendingComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        return (y?.Length ?? 0).CompareTo(x?.Length ?? 0);
    }
}