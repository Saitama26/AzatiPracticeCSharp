using Day4.Task2.Implementations;

namespace Day4.Tests.Task2;

public class BookTests
{
    [Fact]
    public void CompareTo_Null_ThrowsArgumentNullException_WhenBookIsNull()
    {
        // Arrange
        var book = CreateBook();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => book.CompareTo(null));
    }

    [Fact]
    public void CompareTo_DifferentISBN_ReturnsComparisonResult()
    {
        // Arrange
        var book1 = CreateBook(isbn: "111");
        var book2 = CreateBook(isbn: "222");

        // Act
        var result1 = book1.CompareTo(book2);
        var result2 = book2.CompareTo(book1);

        // Assert
        Assert.True(result1 < 0);
        Assert.True(result2 > 0);
    }

    [Fact]
    public void CompareTo_SameISBN_DifferentAuthor_ReturnsComparisonResult()
    {
        // Arrange
        var book1 = CreateBook(isbn: "123", author: "Alice");
        var book2 = CreateBook(isbn: "123", author: "Bob");

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void CompareTo_SameISBNAndAuthor_DifferentTitle_ReturnsComparisonResult()
    {
        // Arrange
        var book1 = CreateBook(isbn: "123", author: "Author", title: "AAA");
        var book2 = CreateBook(isbn: "123", author: "Author", title: "BBB");

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void CompareTo_SameISBNAuthorTitle_DifferentYear_ReturnsComparisonResult()
    {
        // Arrange
        var book1 = CreateBook(year: 1999);
        var book2 = CreateBook(year: 2000);

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void CompareTo_IdenticalBooks_ReturnsZero()
    {
        // Arrange
        var book1 = CreateBook();
        var book2 = CreateBook();

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var book = CreateBook();

        // Act
        var result = book.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_SameISBN_ReturnsTrue()
    {
        // Arrange
        var book1 = CreateBook(isbn: "ABC");
        var book2 = CreateBook(isbn: "abc");

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_DifferentISBN_ReturnsFalse()
    {
        // Arrange
        var book1 = CreateBook(isbn: "111");
        var book2 = CreateBook(isbn: "222");

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_ObjectOverride_WorksCorrectly()
    {
        // Arrange
        var book1 = CreateBook(isbn: "123");
        object book2 = CreateBook(isbn: "123");

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetHashCode_NullISBN_ReturnsZero()
    {
        // Arrange
        var book = CreateBook(isbn: null);

        // Act
        var hash = book.GetHashCode();

        // Assert
        Assert.Equal(0, hash);
    }

    [Fact]
    public void GetHashCode_SameISBN_ReturnsSameHash()
    {
        // Arrange
        var book1 = CreateBook(isbn: "123");
        var book2 = CreateBook(isbn: "123");

        // Act
        var hash1 = book1.GetHashCode();
        var hash2 = book2.GetHashCode();

        // Assert
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void GetHashCode_DifferentISBN_ReturnsDifferentHash()
    {
        // Arrange
        var book1 = CreateBook(isbn: "111");
        var book2 = CreateBook(isbn: "222");

        // Act
        var hash1 = book1.GetHashCode();
        var hash2 = book2.GetHashCode();

        // Assert
        Assert.NotEqual(hash1, hash2);
    }

    private Book CreateBook(
        string isbn = "123",
        string author = "Author",
        string title = "Title",
        string publishing = "Pub",
        int year = 2000,
        int pages = 100,
        double price = 10.0)
    {
        return new Book
        {
            ISBN = isbn,
            Author = author,
            Title = title,
            Publishing = publishing,
            YearOfPublication = year,
            PagesCount = pages,
            Price = price
        };
    }
}