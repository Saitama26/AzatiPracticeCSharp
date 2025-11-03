using PracticeSolution;

namespace TestUnits
{
    public class NewtonRootFinderTestTask1
    {
        [Theory]
        //Arrange
        [InlineData(0, 3, 2, 0)]
        [InlineData(2, 2, 5, 1.41421)]
        [InlineData(15, 7, 10, 1.4723567001)]
        [InlineData(145, 15, 6, 1.393449)]
        [InlineData(1197, 124, 15, 1.058822935014055)]
        [InlineData(-1197, 5, 5, -4.12685)]
        public void TestFindRoot(double num, int n, int accuracy, double expected)
        {
            //Act
            double res = num.FindNthRoot(n, accuracy);
            //Assert
            Assert.Equal(expected, res);
        }

        [Fact]
        public void TestNegariveRoot() 
        {
            //Arrange
            double number = 15.5;
            int root = -5;
            int precision = 5;

            //Act
            var act = new Func<object?>(() => number.FindNthRoot(root, precision));
            //Assert
            Assert.Throws<Exception>(act);
        }

        [Theory]
        //Arrange
        [InlineData(-5, 6, 2)]   
        [InlineData(-16, 2, 2)]  
        [InlineData(-8, 4, 2)]   
        [InlineData(-1, 10, 2)]
        public void FindNthRoot_NegativeValue_ThrowsException(double num, int root, int accuracy)
        {
            // Act
            var act = new Func<object?>(() => num.FindNthRoot(root, accuracy));

            //Assert
            Assert.Throws<Exception>(act);
        }

    }
}