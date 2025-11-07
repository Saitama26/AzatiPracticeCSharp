using Day1.Task1_2;

namespace Day1.Tests.Task1;

public class AlgorithmsRootFinderTests
{
    [Theory]
    [InlineData(0, 3, 2, 0)]
    [InlineData(2, 2, 5, 1.41421)]
    [InlineData(15, 7, 10, 1.4723567001)]
    [InlineData(145, 15, 6, 1.393449)]
    [InlineData(1197, 124, 15, 1.058822935014055)]
    [InlineData(-1197, 5, 5, -4.12685)]
    [InlineData(int.MaxValue, 2, 6, 46340.950001)] 
    [InlineData(int.MinValue, 3, 3, -1290.159)]   
    public void FindNthRoot_ReturnsExpected(double value, int degree, int accuracy, double expected)
    {
        //Act
        var res = Algorithms.FindNthRoot(value, degree, accuracy);
        //Assert
        Assert.Equal(expected, res);
    }

    [Fact]
    public void FindNthRoot_NegativeDegree_ThrowsArgumentOutOfRange()
    {
        // Arrange
        var value = 15.5;
        var degree = -5;
        var accuracy = 5;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.FindNthRoot(value, degree, accuracy));
    }

    [Fact]
    public void FindNthRoot_NegativeAccuracy_ThrowsArgumentOutOfRange()
    {
        // Arrange
        var value = 15.5;
        var degree = 2;
        var accuracy = -5;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.FindNthRoot(value, degree, accuracy));
    }

    [Fact]
    public void FindNthRoot_NegativeInfinity_ThrowsArgumentException()
    {
        // Arrange
        var value = double.NegativeInfinity;
        var degree = 5;
        var accuracy = 5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Algorithms.FindNthRoot(value, degree, accuracy));
    }

    [Fact]
    public void FindNthRoot_PositiveInfinity_ThrowsArgumentException()
    {
        // Arrange
        var value = double.PositiveInfinity;
        var degree = 5;
        var accuracy = 5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Algorithms.FindNthRoot(value, degree, accuracy));
    }

    [Fact]
    public void FindNthRoot_IsNaN_ThrowsArgumentException()
    {
        // Arrange
        var value = double.NegativeInfinity;
        var degree = 5;
        var accuracy = 5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Algorithms.FindNthRoot(value, degree, accuracy));
    }

    [Theory]
    [InlineData(-5, 6, 2)]   
    [InlineData(-16, 2, 2)]  
    [InlineData(-8, 4, 2)]   
    [InlineData(-1, 10, 2)] 
    public void FindNthRoot_NegativeValueEvenDegree_ThrowsArgumentException(double value, int degree, int accuracy)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Algorithms.FindNthRoot(value, degree, accuracy));
    }
}

