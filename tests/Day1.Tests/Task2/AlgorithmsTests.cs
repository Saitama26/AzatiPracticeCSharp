using Day1.Task2;

namespace Day1.Tests.Task2;

public partial class AlgorithmsTests
{
    [Theory]
    [InlineData(12, 21)]       
    [InlineData(513, 531)]     
    [InlineData(2017, 2071)]   
    [InlineData(1234, 1243)]   
    [InlineData(534976, 536479)] 
    [InlineData(4321, null)]   
    [InlineData(9, null)]      
    [InlineData(int.MaxValue, null)]
    public void NextBiggerThan_ReturnsExpected(int number, int? expected)
    {
        //Act
        var res = Algorithms.NextBiggerThan(number);

        //Assert
        Assert.Equal(expected, res);

    }

    [Fact]
    public void NextBiggerThan_NegativeNumber_ThrowsArgumentException_WhenValueIsMinValue()
    {
        //Arrange
        var number = int.MinValue;

        //Assert & Act
        Assert.Throws<ArgumentException>(() => Algorithms.NextBiggerThan(number));
    }
}