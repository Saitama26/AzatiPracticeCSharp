namespace Day3Solution.task1
{
    public static class ArrayExtension
    {
        public static int[] Filter(this int[] array, Predicate<int> predicate)
        {
            if (array == null) throw new ArgumentNullException("Array can't be null");
            if (predicate == null) throw new ArgumentNullException("Predicate can't be null");

            List<int> result = new List<int>();

            foreach (int i in array)
            {
                if (predicate(i))
                    result.Add(i);
            }

            return result.ToArray();
        }
        public static bool Contain(this int n1, int n2)
        {
            string s1 = n1.ToString();
            string s2 = n2.ToString();

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
