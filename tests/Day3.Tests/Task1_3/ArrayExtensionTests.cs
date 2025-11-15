using Day3.Task1_3;
using Day3.Task1_3.Filters;
using Day3.Task1_3.Transformers;
using Day3.Task1_3.Comparers;

namespace Day3.Tests.Task1_3;

public class ArrayExtensionTests
{
    [Fact]
    public void Filter_ArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => array.Filter(new EvenNumberFilter()));
    }

    [Fact]
    public void Filter_PredicateIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => array.Filter(null));
    }

    [Theory]
    [InlineData(new int[] { 12, 23, 34 }, 2, new int[] { 12, 23 })]
    [InlineData(new int[] { 45, 56, 67 }, 7, new int[] { 67 })]
    public void Filter_ByContainDigit_ReturnsExpected(int[] source, int digit, int[] expected)
    {
        // Act
        var result = source.Filter(new ContainsDigitFilter(digit));

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 4 })]
    [InlineData(new int[] { -5, -2, 0, 7 }, new int[] { -2, 0 })]
    public void Filter_ByEvenNumbers_ReturnsExpected(int[] source, int[] expected)
    {
        // Act
        var result = source.Filter(new EvenNumberFilter());

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 121, 44, 1331, 123 }, new int[] { 121, 44, 1331 })]
    [InlineData(new int[] { 10, 22, 303, 45 }, new int[] { 22, 303 })]
    public void Filter_ByPalindrome_ReturnsExpected(int[] source, int[] expected)
    {
        // Act
        var result = source.Filter(new PalindromeFilter());

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new double[] { -23.809 }, new string[] { "minus two three point eight zero nine" })]
    [InlineData(new double[] { 0.295 }, new string[] { "zero point two nine five" })]
    [InlineData(new double[] { 15.17 }, new string[] { "one five point one seven" })]
    public void Transform_ToEnglishWords_WorksCorrectly(double[] input, string[] expected)
    {
        // Act
        var result = input.Transform(new DoubleToStringTransformer("eng"));

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
        var result = input.Transform(new DoubleToStringTransformer("rus"));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortBy_LengthAscending()
    {
        // Arrange
        string[] input = { "apple", "kiwi", "banana", "pear" };

        // Act
        var result = input.SortBy(new StringLengthAscendingComparer());

        // Assert
        Assert.Equal(new[] { "kiwi", "pear", "apple", "banana" }, result);
    }

    [Fact]
    public void SortBy_LengthDescending()
    {
        // Arrange
        string[] input = { "apple", "kiwi", "banana", "pear" };

        // Act
        var result = input.SortBy(new StringLengthDescendingComparer());

        // Assert
        Assert.Equal(new[] { "banana", "apple", "kiwi", "pear" }, result);
    }

    [Fact]
    public void SortBy_CharCountAscending()
    {
        // Arrange
        string[] input = { "apple", "banana", "kiwi", "pear" };

        // Act
        var result = input.SortBy(new CharCountAscendingComparer('a'));

        // Assert
        Assert.Equal(new[] { "kiwi", "apple", "pear", "banana" }, result);
    }

    [Fact]
    public void SortBy_CharCountDescending()
    {
        // Arrange
        string[] input = { "apple", "banana", "kiwi", "pear" };

        // Act
        var result = input.SortBy(new CharCountDescendingComparer('a'));

        // Assert
        Assert.Equal(new[] { "banana", "apple", "pear", "kiwi" }, result);
    }

    [Fact]
    public void SortBy_ArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        string[] input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input.SortBy(new StringLengthAscendingComparer()));
    }

    [Fact]
    public void SortBy_ComparerIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        string[] input = { "apple", "banana" };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input.SortBy(null));
    }
}