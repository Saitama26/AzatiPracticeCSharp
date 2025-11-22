namespace Day4.Task2.Implementations.Comparers;

public class SortByAuthor : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        return string.Compare(x.Author, y.Author, StringComparison.OrdinalIgnoreCase);
    }
}