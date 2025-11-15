namespace Day4.Task2.Implementations.Comparers;

public class SortByTitle : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
    }
}