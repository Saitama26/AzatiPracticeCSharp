using Day4.Task1.Implementation;
using Day4.Task1.Interfaces;

namespace Day4.Tests.Task1;

public class EuclideanGcdAlgorithmTests
{
    private readonly IGcdAlgorithm _algorithm = new EuclideanGcdAlgorithm();

    [Fact]
    public void Calculate_CommonCase_ReturnsCorrectGcd()
    {
        // Arrange
        var a = 252;
        var b = 105;

        // Act
        var result = _algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_WhenNumbersAreEqual_ReturnsSameNumber()
    {
        // Arrange
        var a = 42;
        var b = 42;

        // Act
        var result = _algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Calculate_WhenOneNumberIsZero_ReturnsAbsoluteOfOther()
    {
        // Arrange
        var a = 0;
        var b = 15;

        // Act
        var result = _algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Calculate_WhenBothNumbersAreZero_ReturnsZero()
    {
        // Arrange
        var a = 0;
        var b = 0;

        // Act
        var result = _algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Calculate_NegativeNumbers_ReturnsPositiveGcd()
    {
        // Arrange
        var a = -48;
        var b = 18;

        // Act
        var result = _algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Calculate_LargeNumbers_ReturnsCorrectGcd()
    {
        // Arrange
        var a = 123456;
        var b = 789012;

        // Act
        var result = _algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(12, result);
    }
}