using Day4.Task2.Interfaces;

namespace Day4.Task2.Implementations;

public class BookStorage : IBookStorage
{
    private List<Book> _books;

    public BookStorage(List<Book> books)
    {
        _books = books ?? throw new ArgumentNullException(nameof(books));
    }

    public IEnumerable<Book> Load() => _books.ToList();

    public void Save(IEnumerable<Book> books)
    {
        if (books == null) throw new ArgumentNullException(nameof(books));
        _books = books.ToList();
    }
}