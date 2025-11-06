using Day2.Task1_2;

namespace Day2.Tests.Task1;
public class TransformerTest
{
    [Theory]
    //Arrange 
    [InlineData(0, "zero")]
    [InlineData(12, "one two")]
    [InlineData(-45, "minus four five")]
    [InlineData(23.809, "two three point eight zero nine")]
    [InlineData(-0.56, "minus zero point five six")]
    public void TransformNumberToWordsTest(double number, string expected)
    {
        // Act
        var result = Transformer.TransformToWordsEng(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TransformToWordsEng_ThrowNaNException()
    {
        //Arrange
        double number = double.NaN;

        //Assert & Act
        Assert.Throws<ArgumentException>(() => Transformer.TransformToWordsEng(number));
    }

    [Fact]
    public void TransformToWordsEng_ThrowPosInfinityException()
    {
        //Arrange
        double number = double.PositiveInfinity;

        //Assert & Act
        Assert.Throws<ArgumentException>(() => Transformer.TransformToWordsEng(number));
    }

    [Fact]
    public void TransformToWordsEng_ThrowNegInfinityException()
    {
        // Arrange
        double number = double.NegativeInfinity;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Transformer.TransformToWordsEng(number));

    }
}