using Day2Solution;
using Day2Solution.Task2DoubleExtension;


namespace Day2SolutionTest
{
    public class ArrayTransformingTest
    {
        [Theory]
        [InlineData(new double[] { -23.809 }, new string[] { "minus two three point eight zero nine" })]
        [InlineData(new double[] { 12 }, new string[] { "one two" })]
        [InlineData(new double[] { 3.5 }, new string[] { "three point five" })]
        [InlineData(new double[] { 0 }, new string[] { "zero" })]
        [InlineData(new double[] { 7, 45 }, new string[] { "seven", "four five" })]
        public void GetStringRepresentation_ValidArrays_ReturnExpectedWords(double[] numbers, string[] expected)
        {
            // Arrange
            var input = numbers;

            // Act
            var result = input.GetStringRepresentation();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetStringRepresentation_NullArray_ThrowsException()
        {
            // Arrange
            double[] numbers = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => numbers.GetStringRepresentation());
        }

        [Fact]
        public void GetStringRepresentation_EmptyArray_ThrowsException()
        {
            // Arrange
            double[] numbers = Array.Empty<double>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
        }

        [Fact]
        public void GetStringRepresentation_ArrayWithNaN_ThrowsException()
        {
            // Arrange
            double[] numbers = { 1.0, double.NaN };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
        }

        [Fact]
        public void GetStringRepresentation_ArrayWithPositiveInfinity_ThrowsException()
        {
            // Arrange
            double[] numbers = { 1.0, double.PositiveInfinity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
        }

        [Fact]
        public void GetStringRepresentation_ArrayWithNegativeInfinity_ThrowsException()
        {
            // Arrange
            double[] numbers = { 1.0, double.NegativeInfinity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => numbers.GetStringRepresentation());
        }


    }
}
