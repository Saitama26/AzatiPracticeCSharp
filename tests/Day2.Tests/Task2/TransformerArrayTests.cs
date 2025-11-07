using Day2.Task1_2;

namespace Day2.Tests.Task2;
public class TransformerArrayTests
{
    [Theory]
    [InlineData(new double[] { -23.809 }, new string[] { "minus two three point eight zero nine" })]
    [InlineData(new double[] { 12 }, new string[] { "one two" })]
    [InlineData(new double[] { 3.5 }, new string[] { "three point five" })]
    [InlineData(new double[] { 0 }, new string[] { "zero" })]
    [InlineData(new double[] { 7, 45 }, new string[] { "seven", "four five" })]
    public void GetStringRepresentation_ValidArrays_ReturnExpectedWords(double[] numbers, string[] expected)
    {
        // Arrange
        var input = numbers;

        // Act
        var result = input.GetStringRepresentation();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetStringRepresentation_NullArray_ThrowsArgumentNullException_WhenArrayIsNull()
    {
        // Arrange
        double[] numbers = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => numbers.GetStringRepresentation());
    }

    [Fact]
    public void GetStringRepresentation_EmptyArray_ThrowsArgumentException_WhenArrayIsEmpty()
    {
        // Arrange
        double[] numbers = Array.Empty<double>();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
    }

    [Fact]
    public void GetStringRepresentation_ArrayWithNaN_ThrowsArgumentException_WhenArrayContainsNaN()
    {
        // Arrange
        double[] numbers = { 1.0, double.NaN };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
    }

    [Fact]
    public void GetStringRepresentation_ArrayWithPositiveInfinity_ThrowsArgumentException_WhenArrayContainsPositiveInfinity()
    {
        // Arrange
        double[] numbers = { 1.0, double.PositiveInfinity };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
    }

    [Fact]
    public void GetStringRepresentation_ArrayWithNegativeInfinity_ThrowsArgumentException_WhenArrayContainsNegativeInfinity()
    {
        // Arrange
        double[] numbers = { 1.0, double.NegativeInfinity };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
    }
}