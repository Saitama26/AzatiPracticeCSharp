using Day2.Task1_2;
namespace Day2.Tests.Task1;
public class TransformerTests
{
    [Theory]
    [InlineData(0, "zero")]
    [InlineData(12, "one two")]
    [InlineData(-45, "minus four five")]
    [InlineData(23.809, "two three point eight zero nine")]
    [InlineData(-0.56, "minus zero point five six")]
    public void TransformNumberToWordsTest(double number, string expected)
    {
        // Act
        var result = Transformer.TransformToWords(number, "eng");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TransformToWordsEng_NaNValue_ThrowsArgumentException_WhenValueIsNaN()
    {
        //Arrange
        var number = double.NaN;

        //Assert & Act
        Assert.Throws<ArgumentException>(() => Transformer.TransformToWords(number, "eng"));
    }

    [Fact]
    public void TransformToWordsEng_PositiveInfinity_ThrowsArgumentException_WhenValueIsPositiveInfinity()
    {
        //Arrange
        var number = double.PositiveInfinity;

        //Assert & Act
        Assert.Throws<ArgumentException>(() => Transformer.TransformToWords(number, "eng"));
    }

    [Fact]
    public void TransformToWordsEng_NegativeInfinity_ThrowsArgumentException_WhenValueIsNegativeInfinity()
    {
        // Arrange
        var number = double.NegativeInfinity;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Transformer.TransformToWords(number, "eng"));
    }
}