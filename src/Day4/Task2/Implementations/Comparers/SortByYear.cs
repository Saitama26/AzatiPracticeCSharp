namespace Day4.Task2.Implementations.Comparers;

public class SortByYear : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        return x.YearOfPublication.CompareTo(y.YearOfPublication);
    }
}