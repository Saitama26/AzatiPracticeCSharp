using Day3.Task1_3.Interfaces;
namespace Day3.Task1_3.Filters;
public class PalindromeFilter : IPredicate<int>
{
    public bool IsMatched(int element)
    {
        string s = element.ToString();
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        return s == reversed;
    }
}
