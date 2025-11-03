using Day3Solution.task1;

namespace Day3SolutionTest
{
    public class ArrayExtensionTest
    {
        [Fact]
        public void Filter_ArrayIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => array.Filter(x => x > 0));
        }

        [Fact]
        public void Filter_PredicateIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array = { 1, 2, 3 };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => array.Filter(null));
        }

        [Theory]
        // Arrange
        [InlineData(new int[] { 12, 23, 34 }, 2, new int[] { 12, 23 })]
        [InlineData(new int[] { 45, 56, 67 }, 7, new int[] { 67 })]
        public void Filter_ByContainDigit_ReturnsExpected(int[] source, int digit, int[] expected)
        {

            // Act
            var result = source.Filter(x => x.Contain(digit));

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        // Arrange
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 4 })]
        [InlineData(new int[] { -5, -2, 0, 7 }, new int[] { -2, 0 })]
        public void Filter_ByEvenNumbers_ReturnsExpected(int[] source, int[] expected)
        {
            // Act
            var result = source.Filter(x => x % 2 == 0);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        // Arrange
        [InlineData(new int[] { 121, 44, 1331, 123 }, new int[] { 121, 44, 1331 })]
        [InlineData(new int[] { 10, 22, 303, 45 }, new int[] { 22, 303 })]
        public void Filter_ByPalindrome_ReturnsExpected(int[] source, int[] expected)
        {
            // Act
            var result = source.Filter(x => x.IsPalindrome());

            // Assert
            Assert.Equal(expected, result);
        }
    }
}