using Day4.Task2.Interfaces;

namespace Day4.Task2.Implementations;

public class Book : IEquatable<Book>, IComparable<Book>
{
    private IIsbnValidator _IsbnValidator;
    public string ISBN;
    public string Author;
    public string Title;
    public string Publishing;
    public int YearOfPublication;
    public int PagesCount;
    public double Price;
    
    public IIsbnValidator IsbnValidator
    {
        get => _IsbnValidator;
        set => _IsbnValidator = value ?? throw new ArgumentNullException($"{nameof(value)} can't be null");
    }

    public Book() { }

    public Book(IIsbnValidator isbnValidator)
    {
        _IsbnValidator = isbnValidator ?? throw new ArgumentNullException($"{nameof(isbnValidator)} can't be null");
    }

    public int CompareTo(Book? other)
    {
        if(other is null) 
        {
            throw new ArgumentNullException($"{nameof(other)} can't be null");
        }

        var ISBNComparison = string.Compare(ISBN, other.ISBN, StringComparison.OrdinalIgnoreCase);
        if (ISBNComparison != 0)
        {
            return ISBNComparison;
        }

        var authorComparison = string.Compare(Author, other.Author, StringComparison.OrdinalIgnoreCase);
        if ( authorComparison != 0 )
        {
            return authorComparison;
        }
        
        var titleComparison = string.Compare(Title, other.Title, StringComparison.OrdinalIgnoreCase);
        if ( titleComparison != 0 )
        {
            return titleComparison;
        }

        return YearOfPublication.CompareTo(other.YearOfPublication);
    }

    public bool Equals(Book? other)
    {
        if (other is null)
        {
            return false;
        }

        return string.Equals(ISBN, other.ISBN, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Book);
    }

    public override int GetHashCode()
    {
        return ISBN?.GetHashCode() ?? 0;
    }

    public bool Validate()
    {
        if(_IsbnValidator == null)
        {
            throw new InvalidOperationException($"{_IsbnValidator} is not set");
        }

        return _IsbnValidator.Validate(ISBN);
    }
}