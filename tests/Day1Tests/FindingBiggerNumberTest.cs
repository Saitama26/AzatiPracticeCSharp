using Day1Solution;
namespace TestUnits
{
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
        public void TestFindindBiggerNumbers(int number, int? expected)
        {
            //Act
            var res = Day1Task2.NextBiggerThan(number);

            //Assert
            Assert.Equal(expected, res);

        }

        [Fact]
        public void FindingBiggerNumber_NegariveNumber_ThrowExeption()
        {
            //Arrange
            int number = -54;

            //Assert & Act
            Assert.Throws<ArgumentException>(() => Day1Task2.NextBiggerThan(number));
        }


    }
}
