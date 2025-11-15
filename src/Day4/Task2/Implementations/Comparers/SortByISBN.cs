namespace Day4.Task2.Implementations.Comparers;

public class SortByISBN : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        return string.Compare(x.ISBN, y.ISBN, StringComparison.OrdinalIgnoreCase);
    }
}