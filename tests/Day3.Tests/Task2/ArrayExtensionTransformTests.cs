using Day3.task1_3;
using Day2.Task1_2;

namespace Day3.Tests.Task2;

public class ArrayExtensionTransformTests
{
    [Theory]
    [InlineData(new double[] { -23.809 }, new string[] { "minus two three point eight zero nine" })]
    [InlineData(new double[] { 0.295 }, new string[] { "zero point two nine five" })]
    [InlineData(new double[] { 15.17 }, new string[] { "one five point one seven" })]
    public void Transform_ToEnglishWords_WorksCorrectly(double[] input, string[] expected)
    {

        // Act
        string[] result = input.Transform(x => Transformer.TransformToWordsEng(x));

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new double[] { -23.809 }, new string[] { "минус два три точка восемь ноль девять" })]
    [InlineData(new double[] { 0.295 }, new string[] { "ноль точка два девять пять" })]
    [InlineData(new double[] { 15.17 }, new string[] { "один пять точка один семь" })]
    public void Transform_ToRussianWords_WorksCorrectly(double[] input, string[] expected)
    {

        // Act
        string[] result = input.Transform(x => Transformer.TransformToWordsRus(x));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Transform_ArrayIsNull_ThrowsArgumentNullException_WhenArrayIsNull()
    {
        // Arrange
        double[] input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input.Transform(x => x.ToString()));
    }

    [Fact]
    public void Transform_FuncIsNull_ThrowsArgumentNullException_WhenFuncIsNull()
    {
        // Arrange
        double[] input = { 1.0 };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input.Transform<string>(null));
    }
}
