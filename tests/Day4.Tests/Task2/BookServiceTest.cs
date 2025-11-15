using Day4.Task2.enums;
using Day4.Task2.Implementations;

namespace Day4.Tests.Task2;

public class BookServiceTest
{

    [Fact]
    public void Add_ThrowsArgumentNullException_WhenBookIsNull()
    {
        // Arrange
        var service = CreateServiceWithBooks();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => service.Add(null));
    }

    [Fact]
    public void Add_ThrowsInvalidOperationException_WhenBookAlreadyExists()
    {
        // Arrange
        var service = CreateServiceWithBooks();
        var existing = new Book { ISBN = "111", Author = "AuthorA" };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => service.Add(existing));
    }

    [Fact]
    public void Add_ShouldAddBook_WhenBookIsNew()
    {
        // Arrange
        var service = CreateServiceWithBooks();
        var newBook = new Book { ISBN = "444", Author = "AuthorD", Title = "TitleD", Publishing = "PubD", YearOfPublication = 2021, PagesCount = 400, Price = 40.0 };

        // Act
        service.Add(newBook);

        // Assert
        Assert.Contains(newBook, service.SortBy(BookTag.ISBN));
    }

    [Fact]
    public void Remove_ThrowsArgumentNullException_WhenBookIsNull()
    {
        // Arrange
        var service = CreateServiceWithBooks();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => service.Remove(null));
    }

    [Fact]
    public void Remove_ThrowsInvalidOperationException_WhenBookDoesNotExist()
    {
        // Arrange
        var service = CreateServiceWithBooks();
        var nonExisting = new Book { ISBN = "999", Author = "NoAuthor" };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => service.Remove(nonExisting));
    }

    [Fact]
    public void Remove_ShouldRemoveBook_WhenBookExists()
    {
        // Arrange
        var service = CreateServiceWithBooks();
        var existing = new Book { ISBN = "111", Author = "AuthorA" };

        // Act
        service.Remove(existing);

        // Assert
        Assert.DoesNotContain(existing, service.SortBy(BookTag.ISBN));
    }

    [Theory]
    [InlineData(BookTag.ISBN, "111", 1)]
    [InlineData(BookTag.Author, "AuthorB", 1)]
    [InlineData(BookTag.Title, "TitleC", 1)]
    [InlineData(BookTag.Publishing, "PubA", 1)]
    [InlineData(BookTag.Year, 2010, 1)]
    [InlineData(BookTag.PagesCount, 300, 1)]
    [InlineData(BookTag.Price, 20.0, 1)]
    public void FindByTag_ShouldReturnCorrectBooks(BookTag tag, object value, int expectedCount)
    {
        // Arrange
        var service = CreateServiceWithBooks();

        // Act
        var result = service.FindByTag(tag, value);

        // Assert
        Assert.Equal(expectedCount, new List<Book>(result).Count);
    }

    [Fact]
    public void FindByTag_ThrowsArgumentOutOfRangeException_WhenTagIsUnknown()
    {
        // Arrange
        var service = CreateServiceWithBooks();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => service.FindByTag((BookTag)999, "value"));
    }

    [Theory]
    [InlineData(BookTag.ISBN)]
    [InlineData(BookTag.Author)]
    [InlineData(BookTag.Title)]
    [InlineData(BookTag.Publishing)]
    [InlineData(BookTag.Year)]
    [InlineData(BookTag.PagesCount)]
    [InlineData(BookTag.Price)]
    public void SortBy_ShouldSortBooks(BookTag tag)
    {
        // Arrange
        var service = CreateServiceWithBooks();

        // Act
        var sorted = service.SortBy(tag).ToList();

        // Assert
        Assert.NotEmpty(sorted);

        for (var i = 0; i < sorted.Count - 1; i++)
        {
            var comparison = tag switch
            {
                BookTag.ISBN => string.Compare(sorted[i].ISBN, sorted[i + 1].ISBN, StringComparison.OrdinalIgnoreCase),
                BookTag.Author => string.Compare(sorted[i].Author, sorted[i + 1].Author, StringComparison.OrdinalIgnoreCase),
                BookTag.Title => string.Compare(sorted[i].Title, sorted[i + 1].Title, StringComparison.OrdinalIgnoreCase),
                BookTag.Publishing => string.Compare(sorted[i].Publishing, sorted[i + 1].Publishing, StringComparison.OrdinalIgnoreCase),
                BookTag.Year => sorted[i].YearOfPublication.CompareTo(sorted[i + 1].YearOfPublication),
                BookTag.PagesCount => sorted[i].PagesCount.CompareTo(sorted[i + 1].PagesCount),
                BookTag.Price => sorted[i].Price.CompareTo(sorted[i + 1].Price),
                _ => throw new ArgumentOutOfRangeException(nameof(tag))
            };

            Assert.True(comparison <= 0, $"Sorting is broken {tag}: {sorted[i]} > {sorted[i + 1]}");
        }
    }

    [Fact]
    public void SortBy_ShouldThrow_WhenTagIsUnknown()
    {
        // Arrange
        var service = CreateServiceWithBooks();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => service.SortBy((BookTag)999));
    }

    [Fact]
    public void Save_ShouldPersistBooks()
    {
        // Arrange
        var storage = new BookStorage(new List<Book>());
        var service = new BookService(storage);
        var newBook = new Book { ISBN = "555", Author = "AuthorE" };

        // Act
        service.Add(newBook);
        service.Save();

        // Assert
        var loaded = storage.Load();
        Assert.Contains(newBook, loaded);
    }

    private BookService CreateServiceWithBooks()
    {
        var books = new List<Book>
        {
            new Book { ISBN = "111", Author = "AuthorA", Title = "TitleA", Publishing = "PubA", YearOfPublication = 2000, PagesCount = 100, Price = 10.0 },
            new Book { ISBN = "222", Author = "AuthorB", Title = "TitleB", Publishing = "PubB", YearOfPublication = 2010, PagesCount = 200, Price = 20.0 },
            new Book { ISBN = "333", Author = "AuthorC", Title = "TitleC", Publishing = "PubC", YearOfPublication = 2020, PagesCount = 300, Price = 30.0 }
        };

        var storage = new BookStorage(books);
        return new BookService(storage);
    }
}