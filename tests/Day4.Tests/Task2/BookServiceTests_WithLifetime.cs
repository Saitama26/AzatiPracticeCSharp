using Day4.Task2.enums;
using Day4.Task2.Implementations;
using Day4.Task2.Interfaces;
using Day4.Tests.Task2.Fixtures;
using Moq;

namespace Day4.Tests.Task2;

/// <summary>
/// BEST PRACTICE: Using IAsyncLifetime to reset state between tests
/// This ensures complete test isolation while using private fields.
/// </summary>
public class BookServiceTests_WithLifetime : IClassFixture<BookServiceFixture>, IAsyncLifetime
{
    private readonly BookServiceFixture _fixture;
    private Mock<IBookStorage> _mockStorage = null!;
    private BookService _service = null!;

    public BookServiceTests_WithLifetime(BookServiceFixture fixture)
    {
        _fixture = fixture;
    }

    // Called BEFORE each test - ensures fresh state
    public Task InitializeAsync()
    {
        _mockStorage = new Mock<IBookStorage>();
        _mockStorage.Setup(s => s.Load()).Returns(_fixture.GetBooks());
        _service = new BookService(_mockStorage.Object);

        return Task.CompletedTask;
    }

    // Called AFTER each test - cleanup if needed
    public Task DisposeAsync()
    {
        _mockStorage.Reset();
        return Task.CompletedTask;
    }

    [Fact]
    public void Constructor_LoadsBooksFromStorage()
    {
        // Assert
        _mockStorage.Verify(s => s.Load(), Times.Once);
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
    public void Remove_ShouldRemoveBook_WhenBookExists()
    {
        // Arrange
        var existing = new Book { ISBN = "111", Author = "AuthorA" };

        // Act
        _service.Remove(existing);

        // Assert
        Assert.DoesNotContain(existing, _service.SortBy(BookTag.ISBN));
    }

    // All other tests can use _mockStorage and _service directly
    // Each test gets a fresh instance thanks to IAsyncLifetime
}