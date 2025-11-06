using Day1.Task1_2;
namespace Day1Tests;

public class FindingBiggerNumberTest
{
    [Theory]
    //Arrange
    [InlineData(12, 21)]       
    [InlineData(513, 531)]     
    [InlineData(2017, 2071)]   
    [InlineData(1234, 1243)]   
    [InlineData(534976, 536479)] 
    [InlineData(4321, null)]   
    [InlineData(9, null)]      
    [InlineData(int.MaxValue, null)]
    public void TestFindindBiggerNumbers(int number, int? expected)
    {
        //Act
        var res = Algorithms.NextBiggerThan(number);

        //Assert
        Assert.Equal(expected, res);

    }

    [Fact]
    public void FindingBiggerNumber_NegariveNumber_ThrowExeption()
    {
        //Arrange
        int number = int.MinValue;

        //Assert & Act
        Assert.Throws<ArgumentException>(() => Algorithms.NextBiggerThan(number));
    }


}
