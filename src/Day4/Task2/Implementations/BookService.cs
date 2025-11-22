using Day4.Task2.enums;
using Day4.Task2.Implementations.Comparers;
using Day4.Task2.Interfaces;

namespace Day4.Task2.Implementations;

public  class BookService : IBookService
{
    private readonly IBookStorage _bookStorage;
    private readonly List<Book> _books;

    public BookService(IBookStorage bookStorage)
    {
        _bookStorage = bookStorage;
        _books = (List<Book>)_bookStorage.Load();
    }

    public void Add(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException($"{nameof(book)} can't be null");
        }

        if (_books.Contains(book))
        {
            throw new InvalidOperationException("This book already exists");
        }
     
        _books.Add(book);
    }

    public void Remove(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException($"{nameof(book)} can't be null");
        }

        if (!_books.Remove(book))
        {
            throw new InvalidOperationException("This book does'nt exist");
        }
    }

    public IEnumerable<Book> FindByTag(BookTag tag, object value)
    {
        switch(tag)
        {
            case BookTag.ISBN:
                return _books.Where(b => b.ISBN == (string)value);

            case BookTag.Author:
                return _books.Where(b => b.Author == (string)value);

            case BookTag.Title:
                return _books.Where(b => b.Title == (string)value);

            case BookTag.Publishing:
                return _books.Where(b => b.Publishing == (string)value);

            case BookTag.Year:
                return _books.Where(b => b.YearOfPublication == (int)value);

            case BookTag.PagesCount:
                return _books.Where(b => b.PagesCount == (int)value);

            case BookTag.Price:
                return _books.Where(b => b.Price == (double)value);

            default:
                throw new ArgumentOutOfRangeException(nameof(tag), "Unknown search criteria");
        }
    }

    public IEnumerable<Book> SortBy(BookTag SortByTag)
    {
        switch (SortByTag)
        {
            case BookTag.ISBN:
                _books.Sort(new SortByISBN());
                break;

            case BookTag.Author:
                _books.Sort(new SortByAuthor());
                break;

            case BookTag.Title:
                _books.Sort(new SortByTitle());
                break;

            case BookTag.Publishing:
                _books.Sort(new SortByPublishing());
                break;

            case BookTag.Year:
                _books.Sort(new SortByYear());
                break;

            case BookTag.PagesCount:
                _books.Sort(new SortByPagesCount());
                break;

            case BookTag.Price:
                _books.Sort(new SortByPrice());
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(SortByTag), "Unknown search criteria");
        }

        return _books.AsReadOnly();
    }

    public void Save()
    {
        _bookStorage.Save(_books);
    }
}