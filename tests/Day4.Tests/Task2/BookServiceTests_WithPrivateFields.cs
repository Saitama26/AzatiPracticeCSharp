using Day4.Task2.enums;
using Day4.Task2.Implementations;
using Day4.Task2.Interfaces;
using Day4.Tests.Task2.Fixtures;
using Moq;

namespace Day4.Tests.Task2;

/// <summary>
/// Example: BookServiceTests using private mock fields (Constructor approach)
/// This approach is good when all tests need the same mock setup.
/// </summary>
public class BookServiceTests_WithPrivateFields : IClassFixture<BookServiceFixture>
{
    private readonly BookServiceFixture _fixture;
    private readonly Mock<IBookStorage> _mockStorage;
    private readonly BookService _service;

    public BookServiceTests_WithPrivateFields(BookServiceFixture fixture)
    {
        _fixture = fixture;

        // Setup mock once in constructor
        _mockStorage = new Mock<IBookStorage>();
        _mockStorage.Setup(s => s.Load()).Returns(_fixture.GetBooks());

        _service = new BookService(_mockStorage.Object);
    }

    [Fact]
    public void Constructor_LoadsBooksFromStorage()
    {
        // No Arrange needed - already done in constructor

        // Assert
        _mockStorage.Verify(s => s.Load(), Times.Once, "Service should load books from storage during construction");
    }

    [Fact]
    public void Add_ThrowsArgumentNullException_WhenBookIsNull()
    {
        // No Arrange needed

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _service.Add(null));
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

    // IMPORTANT: Each test must be independent!
    // Problem: Tests that modify _service state will affect other tests
    // Solution: Use IAsyncLifetime or accept the limitation
}
