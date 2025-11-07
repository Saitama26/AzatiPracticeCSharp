namespace Day3.task1_3
{
    public static partial class ArrayExtension
    {
        public static string[] SortBy(this string[] array, Func<string, string, int> func)
        {
            if (array == null) 
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null"); 
            }
            if (func == null)
            {
                throw new ArgumentNullException($"{nameof(func)} can't be null"); 
            }

            string[] sort = (string[])array.Clone();
            Array.Sort(sort, (x, y) => func(x, y));

            return sort;
        }

        public static T[] Transform<T>(this double[] array, Func<double, T> func)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }
            if (func == null)
            {
                throw new ArgumentNullException($"{nameof(func)} can't be null");
            }

            List<T> list = new List<T>();

            foreach (var item in array)
                list.Add(func(item));

            return list.ToArray<T>();
        }

        public static int[] Filter(this int[] array, Predicate<int> predicate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be null");
            }

            List<int> result = new List<int>();

            foreach (int i in array)
                if (predicate(i))
                    result.Add(i);

            return result.ToArray();
        }
        public static bool Contain(this int number1, int number2)
        {
            string s1 = number1.ToString();
            string s2 = number2.ToString();

            return s1.Contains(s2);
        }

        public static bool IsPalindrome(this int number)
        {
            string s = number.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);

            return s == reversed;
        }
    }
}
