using Day4.Task2.enums;
using Day4.Task2.Implementations;
using Day4.Task2.Interfaces;
using Day4.Tests.Task2.Fixtures;
using Moq;

namespace Day4.Tests.Task2;

public class BookServiceTests : IClassFixture<BookServiceFixture>, IAsyncLifetime
{
    private readonly BookServiceFixture _fixture;
    private Mock<IBookStorage> _mockStorage = null!;
    private BookService _service = null!;

    public BookServiceTests(BookServiceFixture fixture)
    {
        _fixture = fixture;
    }

    // Called before each test - ensures fresh state
    public Task InitializeAsync()
    {
        _mockStorage = new Mock<IBookStorage>();
        _mockStorage.Setup(s => s.Load()).Returns(_fixture.GetBooks());
        _service = new BookService(_mockStorage.Object);
        return Task.CompletedTask;
    }

    // Called after each test - cleanup if needed
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public void Constructor_LoadsBooksFromStorage()
    {
        // Assert
        _mockStorage.Verify(s => s.Load(), Times.Once, "Service should load books from storage during construction");
    }

    [Fact]
    public void Add_ThrowsArgumentNullException_WhenBookIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _service.Add(null));
    }

    [Fact]
    public void Add_ThrowsInvalidOperationException_WhenBookAlreadyExists()
    {
        // Arrange
        var newBook = new Book { ISBN = "999", Author = "AuthorD" };
        _service.Add(newBook);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _service.Add(newBook));
    }

    [Fact]
    public void Add_ShouldAddBook_WhenBookIsNew()
    {
        // Arrange
        var newBook = new Book { ISBN = "444", Author = "AuthorD" };

        // Act
        _service.Add(newBook);

        // Assert
        Assert.Contains(newBook, _service.SortBy(BookTag.ISBN));
        _mockStorage.Verify(s => s.Save(It.IsAny<IEnumerable<Book>>()), Times.Never);
    }

    [Fact]
    public void Remove_ThrowsArgumentNullException_WhenBookIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _service.Remove(null));
    }

    [Fact]
    public void Remove_ThrowsInvalidOperationException_WhenBookDoesNotExist()
    {
        // Arrange
        var nonExisting = new Book { ISBN = "999", Author = "NoAuthor" };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _service.Remove(nonExisting));
    }

    [Fact]
    public void Remove_ShouldRemoveBook_WhenBookExists()
    {
        // Arrange
        var existing = new Book { ISBN = "111", Author = "AuthorA" };

        // Act
        _service.Remove(existing);

        // Assert
        Assert.DoesNotContain(existing, _service.SortBy(BookTag.ISBN));
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
        // Act
        var result = _service.FindByTag(tag, value);

        // Assert
        Assert.Equal(expectedCount, result.Count());
    }

    [Fact]
    public void FindByTag_ThrowsArgumentOutOfRangeException_WhenTagIsUnknown()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _service.FindByTag((BookTag)999, "value"));
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
        // Act
        var sorted = _service.SortBy(tag).ToList();

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
            Assert.True(comparison <= 0);
        }
    }

    [Fact]
    public void SortBy_ShouldThrow_WhenTagIsUnknown()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _service.SortBy((BookTag)999));
    }

    [Fact]
    public void Save_ShouldPersistBooks()
    {
        // Arrange
        var newBook = new Book { ISBN = "555", Author = "AuthorE" };

        // Act
        _service.Add(newBook);
        _service.Save();

        // Assert
        _mockStorage.Verify(s => s.Save(It.Is<IEnumerable<Book>>(books => books.Contains(newBook))), Times.Once);
    }
}