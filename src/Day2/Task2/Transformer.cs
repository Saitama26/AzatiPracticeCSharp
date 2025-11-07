namespace Day2.Task1_2;

public static partial class Transformer
{
    /// <summary>
    /// Converts each element of a <see cref="double[]"/> array into its word-based representation.
    /// Example: new double[] { -23.809 } → { "minus two three point eight zero nine" }.
    /// </summary>
    /// <param name="numbers">The array of double values to be transformed.</param>
    /// <returns>
    /// A string array where each element corresponds to the word representation of the respective number.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the array is empty, or contains <see cref="double.NaN"/>, 
    /// <see cref="double.PositiveInfinity"/>, or <see cref="double.NegativeInfinity"/>.
    /// </exception>
    public static string[] GetStringRepresentation(this double[] numbers)
    {
        if (numbers == null){
            throw new ArgumentNullException(nameof(numbers), "Array of numbers cannot be null.");
        }
        if (numbers.Length == 0){
            throw new ArgumentException("Array of numbers must contain at least one element.", nameof(numbers));
        }
        if (numbers.Any(double.IsNaN)){
            throw new ArgumentException("Array contains NaN values.", nameof(numbers));
        }
        if (numbers.Contains(double.PositiveInfinity) || numbers.Contains(double.NegativeInfinity)){
            throw new ArgumentException("Array contains Infinity values.", nameof(numbers));
        }

        string[] result = new string[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            result[i] = TransformToWordsEng(numbers[i]);
        }

        return result;
    }
}
