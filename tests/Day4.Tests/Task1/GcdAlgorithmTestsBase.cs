using Day4.Task1.Interfaces;

namespace Day4.Tests.Task1;

/// <summary>
/// Base class for testing GCD algorithm implementations.
/// Provides common test cases that should work for any IGcdAlgorithm implementation.
/// </summary>
public abstract class GcdAlgorithmTestsBase
{
    protected abstract IGcdAlgorithm Algorithm { get; }

    [Fact]
    public void Calculate_CommonCase_ReturnsCorrectGcd()
    {
        // Arrange
        var a = 252;
        var b = 105;

        // Act
        var result = Algorithm.Calculate(a, b);

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
        var result = Algorithm.Calculate(a, b);

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
        var result = Algorithm.Calculate(a, b);

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
        var result = Algorithm.Calculate(a, b);

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
        var result = Algorithm.Calculate(a, b);

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
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void Calculate_WhenZeroIsSecondParameter_ReturnsAbsoluteOfFirst()
    {
        // Arrange
        var a = 15;
        var b = 0;

        // Act
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Calculate_BothNegativeNumbers_ReturnsPositiveGcd()
    {
        // Arrange
        var a = -48;
        var b = -18;

        // Act
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Calculate_NegativeFirstPositiveSecond_ReturnsPositiveGcd()
    {
        // Arrange
        var a = 18;
        var b = -48;

        // Act
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Calculate_CoprimeNumbers_ReturnsOne()
    {
        // Arrange - 17 and 19 are both prime numbers, so GCD should be 1
        var a = 17;
        var b = 19;

        // Act
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Calculate_PowersOfTwo_ReturnsCorrectGcd()
    {
        // Arrange - Testing with powers of 2
        var a = 1024; // 2^10
        var b = 512;  // 2^9

        // Act
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(512, result);
    }

    [Theory]
    [InlineData(48, 18, 6)]
    [InlineData(100, 50, 50)]
    [InlineData(13, 13, 13)]
    [InlineData(7, 3, 1)]
    [InlineData(270, 192, 6)]
    public void Calculate_VariousInputs_ReturnsCorrectGcd(int a, int b, int expected)
    {
        // Act
        var result = Algorithm.Calculate(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}
