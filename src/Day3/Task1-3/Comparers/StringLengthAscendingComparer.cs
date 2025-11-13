namespace Day3.Task1_3.Comparers;

public class StringLengthAscendingComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        return (x?.Length ?? 0).CompareTo(y?.Length ?? 0);
    }
}