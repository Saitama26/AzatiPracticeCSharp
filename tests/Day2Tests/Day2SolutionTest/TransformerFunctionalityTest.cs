using Day2Solution.Task1Transformer;

namespace Day2SolutionTest
{
    public class TransformerFunctionalityTest
    {
        [Theory]
        //Arrange 
        [InlineData(0, "zero")]
        [InlineData(12, "one two")]
        [InlineData(-45, "minus four five")]
        [InlineData(23.809, "two three point eight zero nine")]
        [InlineData(-0.56, "minus zero point five six")]
        public void TransformNumberToWordsTest(double number, string expected)
        {
            // Act
            var result = Transformer.TransformToWords(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TransformToWords_ThrowNaNException()
        {
            //Arrange
            double number = double.NaN;

            //Assert & Act
            Assert.Throws<ArgumentException>(() => Transformer.TransformToWords(number));
        }

        [Fact]
        public void TransformToWords_ThrowPosInfinityException()
        {
            //Arrange
            double number = double.PositiveInfinity;

            //Assert & Act
            Assert.Throws<ArgumentException>(() => Transformer.TransformToWords(number));
        }

        [Fact]
        public void TransformToWords_ThrowNegInfinityException()
        {
            // Arrange
            double number = double.NegativeInfinity;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Transformer.TransformToWords(number));

        }
    }
}