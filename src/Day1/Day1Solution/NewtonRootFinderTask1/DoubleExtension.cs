namespace PracticeSolution
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Calculates the n-th root of a number with the given precision
        /// using Newton's method.
        /// </summary>
        /// <param name="num">The number to extract the root from.</param>
        /// <param name="n">The degree of the root (must be positive).</param>
        /// <param name="accuracy">Number of decimal places for the result.</param>
        /// <returns>
        /// The n-th root of <paramref name="num"/> truncated to the specified accuracy.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="num"/> is NaN.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown if <paramref name="n"/> is not positive or if trying to
        /// compute an even root of a negative number.
        /// </exception>
        public static double FindNthRoot(this double num, int n, int accuracy)
        {
            if (num == 0) return 0;
            if (double.IsNaN(num)) throw new ArgumentException("Числе не должно быть NaN");
            if(n < 0) throw new Exception("Степень должна быть положительной");
            if(num < 0 && n % 2 == 0) throw new Exception("Невозможно найти четный корень из отрицательного числа");

            double x = num > 1 ? num : 1;
            double prev = 0;
            double eps = Math.Pow(10, -accuracy);

            do
            {
                prev = x;
                x = ((n - 1) * x + num / Math.Pow(x, n - 1)) / n;

            } while (Math.Abs(x - prev) > eps);

            return x.RoundDown(accuracy);
        }

        private static double RoundDown(this double value, int digits)
        {
            var factor = Math.Pow(10, digits);

            return Math.Truncate(value * factor) / factor;
        }


    }
}
