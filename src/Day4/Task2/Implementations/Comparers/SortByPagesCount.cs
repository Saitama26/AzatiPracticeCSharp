namespace Day4.Task2.Implementations.Comparers;

public class SortByPagesCount : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        return x.PagesCount.CompareTo(y.PagesCount);
    }
}