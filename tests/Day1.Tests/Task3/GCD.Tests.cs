using Day1Solution;

namespace Day1Tests;

public class GcdTests
{

    [Fact]
    public void GetGcdEuclidean_AllZeros_ThrowsArgumentException()
    {
        // Arrange
        int a = 0, b = 0, c = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => GCD.GetGcdEuclidean(a, b, c));
    }

    [Fact]
    public void GetGcdStein_AllZeros_ThrowsArgumentException()
    {
        // Arrange
        int a = 0, b = 0, c = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => GCD.GetGcdStein(a, b, c));
    }


    [Theory]
    // Arrange
    [InlineData(54, 24, 18, 6)] 
    [InlineData(48, 18, 30, 6)] 
    [InlineData(-48, 18, 30, 6)]
    [InlineData(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue)] 
    [InlineData(int.MinValue, int.MinValue, int.MinValue, int.MinValue)] 
    [InlineData(int.MinValue, int.MaxValue, 0, 1)] 
    public void GetGcdEuclidean_ReturnsExpected(int a, int b, int c, int expected)
    {
        // Act
        var result = GCD.GetGcdEuclidean(a, b, c);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    // Arrange
    [InlineData(54, 24, 18, 6)]
    [InlineData(48, 18, 30, 6)]
    [InlineData(-48, 18, 30, 6)]
    [InlineData(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, int.MinValue, int.MinValue, int.MinValue)]
    [InlineData(int.MinValue, int.MaxValue, 0, 1)]
    public void GetGcdStein_ReturnsExpected(int a, int b, int c, int expected)
    {

        // Act
        var result = GCD.GetGcdStein(a, b, c);

        // Assert
        Assert.Equal(expected, result);
    }


    [Theory]
    // Arrange
    [InlineData(54, 24, 18, 6)]
    [InlineData(48, 18, 30, 6)]
    public void GetGcdEuclideanWithTime_ReturnsExpectedAndElapsed(int a, int b, int c, int expected)
    {

        // Act
        var result = GCD.GetGcdEuclidean(a, b, out long elapsed, c);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(elapsed >= 0);
    }

    [Theory]
    // Arrange
    [InlineData(54, 24, 18, 6)]
    [InlineData(48, 18, 30, 6)]
    public void GetGcdSteinWithTime_ReturnsExpectedAndElapsed(int a, int b, int c, int expected)
    {

        // Act
        var result = GCD.GetGcdStein(a, b, out long elapsed, c);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(elapsed >= 0);
    }
}