using Day4.Task2.Interfaces;
using System.Text.RegularExpressions;

namespace Day4.Task2.Implementations;

public class DefaultIsbnValidator : IIsbnValidator
{
    private static readonly string Pattern = @"^(97(8|9))?\d{9}(\d|X)$";

    public bool Validate(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            return false;

        return Regex.IsMatch(isbn, Pattern);
    }
}