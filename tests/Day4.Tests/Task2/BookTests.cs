using Day4.Task2.Implementations;
using Day4.Task2.Interfaces;
using Day4.Tests.Task2.Fixtures;
using Moq;

namespace Day4.Tests.Task2;

public class BookTests : IClassFixture<BookFixture>
{
    private readonly BookFixture _fixture;

    public BookTests(BookFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Helper method to create a mock ISBN validator with specified return value.
    /// </summary>
    private Mock<IIsbnValidator> CreateMockValidator(string isbn, bool isValid)
    {
        var mockValidator = new Mock<IIsbnValidator>();
        mockValidator.Setup(v => v.Validate(isbn)).Returns(isValid);
        return mockValidator;
    }

    [Fact]
    public void Validate_ReturnsTrue_WhenValidatorApproves()
    {
        // Arrange
        var book = _fixture.ValidBook;
        var mockValidator = CreateMockValidator(book.ISBN, true);
        book.IsbnValidator = mockValidator.Object;

        // Act
        var result = book.Validate();

        // Assert
        Assert.True(result);
        mockValidator.Verify(v => v.Validate(book.ISBN), Times.Once);
    }

    [Fact]
    public void Validate_ReturnsFalse_WhenValidatorRejects()
    {
        // Arrange
        var book = _fixture.ValidBook;
        var mockValidator = CreateMockValidator(book.ISBN, false);
        book.IsbnValidator = mockValidator.Object;

        // Act
        var result = book.Validate();

        // Assert
        Assert.False(result);
        mockValidator.Verify(v => v.Validate(book.ISBN), Times.Once);
    }

    [Fact]
    public void CompareTo_ThrowsArgumentNullException_WhenOtherIsNull()
    {
        // Arrange
        var book = _fixture.ValidBook;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => book.CompareTo(null));
    }

    [Fact]
    public void CompareTo_ReturnsZero_WhenBooksAreEqual()
    {
        // Arrange
        var book1 = _fixture.ValidBook;
        var book2 = new Book { ISBN = book1.ISBN, Author = book1.Author, Title = book1.Title, YearOfPublication = book1.YearOfPublication };

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CompareTo_ReturnsNegative_WhenThisIsSmallerThanAnother()
    {
        // Arrange
        var book1 = _fixture.ValidBook;
        var book2 = _fixture.AnotherBook;

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void CompareTo_ReturnsPositive_WhenThisIsGreater()
    {
        // Arrange
        var book1 = _fixture.AnotherBook;
        var book2 = _fixture.ValidBook;

        // Act
        var result = book1.CompareTo(book2);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void Equals_ReturnsFalse_WhenOtherIsNull()
    {
        // Arrange
        var book = _fixture.ValidBook;

        // Act
        var result = book.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_ReturnsTrue_WhenIsbnMatches()
    {
        // Arrange
        var book1 = _fixture.ValidBook;
        var book2 = new Book { ISBN = book1.ISBN };

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_ReturnsFalse_WhenIsbnDiffers()
    {
        // Arrange
        var book1 = _fixture.ValidBook;
        var book2 = _fixture.AnotherBook;

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_ReturnsSame_WhenIsbnSame()
    {
        // Arrange
        var book1 = _fixture.ValidBook;
        var book2 = new Book { ISBN = book1.ISBN };

        // Act
        var hash1 = book1.GetHashCode();
        var hash2 = book2.GetHashCode();

        // Assert
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void GetHashCode_ReturnsZero_WhenIsbnNull()
    {
        // Arrange
        var book = new Book { ISBN = null };

        // Act
        var hash = book.GetHashCode();

        // Assert
        Assert.Equal(0, hash);
    }
}