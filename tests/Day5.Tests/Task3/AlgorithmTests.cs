using Day5.Task3;

namespace Day5.Tests.Task3;

public partial class AlgorithmTests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("([])", true)]
    [InlineData("{[()]}", true)]
    [InlineData("((()))", true)]
    [InlineData("{}[]()", true)]
    public void ValidateBrackets_CorrectSequences_ReturnsTrue(string input, bool expected)
    {
        // Act
        var result = Algorithm.ValidateBrackets(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ValidateBrackets_EmptyString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = "";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Algorithm.ValidateBrackets(input));
    }

    [Fact]
    public void ValidateBrackets_IncorrectSequence_ReturnsFalse()
    {
        // Arrange
        string input = "([)]";

        // Act
        var result = Algorithm.ValidateBrackets(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateBrackets_UnclosedBrackets_ReturnsFalse()
    {
        // Arrange
        string input = "(((";

        // Act
        var result = Algorithm.ValidateBrackets(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateBrackets_ExtraClosingBracket_ReturnsFalse()
    {
        // Arrange
        string input = "())";

        // Act
        var result = Algorithm.ValidateBrackets(input);

        // Assert
        Assert.False(result);
    }
}