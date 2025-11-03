using Day1Solution.GCDFindingTask3;

namespace TestUnits
{
    public class GCDTestTask3
    {
        [Theory]
        // Arrange
        [InlineData(new int[] { 48, 18 }, 6)]
        [InlineData(new int[] { 54, 24 }, 6)]
        [InlineData(new int[] { 7, 13 }, 1)]
        [InlineData(new int[] { 20, 30, 50 }, 10)]
        [InlineData(new int[] { -20, 30 }, 10)]
        public void Euclidean_Gcd_Correct(int[] values, int expected)
        {

            // Act
            var result = GCD.GetGcdEuclidean(values);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Euclidean_Throws_OnNull()
        {
            // Arrange
            int[] input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => GCD.GetGcdEuclidean(input));
        }

        [Fact]
        public void Euclidean_Throws_OnEmpty()
        {
            // Arrange
            var input = Array.Empty<int>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => GCD.GetGcdEuclidean(input));
        }

        [Fact]
        public void Euclidean_WithTime_ReturnsGcdAndTime()
        {
            // Arrange
            var input = new[] { 48, 18 };

            // Act
            var (gcd, elapsed) = GCD.GetGcdEuclideanWithTime(input);

            // Assert
            Assert.Equal(6, gcd);
            Assert.True(elapsed >= 0);
        }


        [Theory]
        // Arrange
        [InlineData(new int[] { 48, 18 }, 6)]
        [InlineData(new int[] { 54, 24 }, 6)]
        [InlineData(new int[] { 7, 13 }, 1)]
        [InlineData(new int[] { 20, 30, 50 }, 10)]
        [InlineData(new int[] { -20, 30 }, 10)]
        public void Stein_Gcd_Correct(int[] values, int expected)
        {

            // Act
            var result = GCD.GetGcdStein(values);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Stein_Throws_OnNull()
        {
            // Arrange
            int[] input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => GCD.GetGcdStein(input));
        }

        [Fact]
        public void Stein_Throws_OnEmpty()
        {
            // Arrange
            var input = Array.Empty<int>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => GCD.GetGcdStein(input));
        }

        [Fact]
        public void Stein_WithTime_ReturnsGcdAndTime()
        {
            // Arrange
            var input = new[] { 48, 18 };

            // Act
            var (gcd, elapsed) = GCD.GetGcdSteinWithTime(input);

            // Assert
            Assert.Equal(6, gcd);
            Assert.True(elapsed >= 0);
        }
    }
}
