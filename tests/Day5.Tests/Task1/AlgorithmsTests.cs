using Day5.Task1;

namespace Day5.Tests.Task1;

public partial class AlgorithmsTests
{
    [Theory]
    [InlineData(new[] { "101", "1110", "-10" }, 2, new[] { 5, 14, -2 })]
    [InlineData(new[] { "1", "0", "1001" }, 2, new[] { 1, 0, 9 })]
    [InlineData(new[] { "11", "100", "1011" }, 2, new[] { 3, 4, 11 })]
    [InlineData(new[] { "77", "123", "-10" }, 8, new[] { 63, 83, -8 })]
    [InlineData(new[] { "1", "7", "70" }, 8, new[] { 1, 7, 56 })]
    [InlineData(new[] { "11", "20", "31" }, 8, new[] { 9, 16, 25 })]
    [InlineData(new[] { "A3", "ff", "10" }, 16, new[] { 163, 255, 16 })]
    [InlineData(new[] { "1", "F", "100" }, 16, new[] { 1, 15, 256 })]
    [InlineData(new[] { "2A", "B4", "-1F" }, 16, new[] { 42, 180, -31 })]
    public void ParseString_WorksCorrectly(string[] inputs, int baseSystem, int[] expected)
    {
        // Act
        var result = Algorithms.ParseString(inputs, baseSystem);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseString_NullInputs_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string> inputs = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Algorithms.ParseString(inputs, 10));
    }

    [Fact]
    public void ParseString_InvalidBase_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var inputs = new[] { "10" };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.ParseString(inputs, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.ParseString(inputs, 17));
    }

    [Fact]
    public void ParseString_EmptyString_ThrowsArgumentException()
    {
        // Arrange
        var inputs = new[] { "" };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Algorithms.ParseString(inputs, 10));
    }

    [Fact]
    public void ParseString_DigitNotValidForBase_ThrowsArgumentException()
    {
        // Arrange
        var inputs = new[] { "9" };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Algorithms.ParseString(inputs, 8));
    }
}