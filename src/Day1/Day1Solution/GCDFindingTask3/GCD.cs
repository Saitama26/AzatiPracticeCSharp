using System.Diagnostics;

namespace Day1Solution.GCDFindingTask3
{
    public class GCD
    {
        private static int GetGcdEuclidean(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return Math.Max(a, b);
        }

        /// <summary>
        /// Вычисляет НОД для списка чисел по алгоритму Евклида.
        /// </summary>
        /// <param name="values">Массив целых чисел (не должен быть null или пустым).</param>
        /// <returns>НОД всех чисел.</returns>
        /// <exception cref="ArgumentNullException">Если массив равен null.</exception>
        /// <exception cref="ArgumentException">Если массив пустой.</exception>
        public static int GetGcdEuclidean(params int[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values), "Input array cannot be null.");
            if (values.Length == 0)
                throw new ArgumentException("At least one value must be provided.", nameof(values));

            var gcd = Math.Abs(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                gcd = GetGcdEuclidean(gcd, values[i]);
            }
            return gcd;
        }

        /// <summary>
        /// Вычисляет НОД для списка чисел по алгоритму Евклида и возвращает время выполнения.
        /// </summary>
        /// <param name="values">Массив целых чисел (не должен быть null или пустым).</param>
        /// <returns>Кортеж: (НОД, время в миллисекундах).</returns>
        /// <exception cref="ArgumentNullException">Если массив равен null.</exception>
        /// <exception cref="ArgumentException">Если массив пустой.</exception>
        public static (int gcd, long elapsedMs) GetGcdEuclideanWithTime(params int[] values)
        {
            var sw = Stopwatch.StartNew();
            var gcd = GetGcdEuclidean(values);
            sw.Stop();
            return (gcd, sw.ElapsedMilliseconds);
        }

        private static int GetGcdStein(int val1, int val2)
        {
            val1 = Math.Abs(val1);
            val2 = Math.Abs(val2);

            if (val1 == 0) return val2;
            if (val2 == 0) return val1;
            if (val1 == val2) return val1;

            bool val1IsEven = (val1 & 1u) == 0;
            bool val2IsEven = (val2 & 1u) == 0;

            if (val1IsEven && val2IsEven)
                return GetGcdStein(val1 >> 1, val2 >> 1) << 1;
            else if (val1IsEven && !val2IsEven)
                return GetGcdStein(val1 >> 1, val2);
            else if (val2IsEven)
                return GetGcdStein(val1, val2 >> 1);
            else if (val1 > val2)
                return GetGcdStein((val1 - val2) >> 1, val2);
            else
                return GetGcdStein(val1, (val2 - val1) >> 1);
        }


        /// <summary>
        /// Вычисляет НОД для списка чисел по алгоритму Стейна.
        /// </summary>
        /// <param name="values">Массив целых чисел (не должен быть null или пустым).</param>
        /// <returns>НОД всех чисел.</returns>
        /// <exception cref="ArgumentNullException">Если массив равен null.</exception>
        /// <exception cref="ArgumentException">Если массив пустой.</exception>
        public static int GetGcdStein(params int[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values), "Input array cannot be null.");
            if (values.Length == 0)
                throw new ArgumentException("At least one value must be provided.", nameof(values));

            var gcd = Math.Abs(values[0]);
            for (int i = 1; i < values.Length; i++)
                gcd = GetGcdStein(gcd, values[i]);
            return gcd;
        }

        /// <summary>
        /// Вычисляет НОД для списка чисел по алгоритму Стейна и возвращает время выполнения.
        /// </summary>
        /// <param name="values">Массив целых чисел (не должен быть null или пустым).</param>
        /// <returns>Кортеж: (НОД, время в миллисекундах).</returns>
        /// <exception cref="ArgumentNullException">Если массив равен null.</exception>
        /// <exception cref="ArgumentException">Если массив пустой.</exception>
        public static (int gcd, long elapsedMs) GetGcdSteinWithTime(params int[] values)
        {
            var sw = Stopwatch.StartNew();
            var gcd = GetGcdStein(values);
            sw.Stop();
            return (gcd, sw.ElapsedMilliseconds);
        }
    }
}
