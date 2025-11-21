using Day4.Task2.Interfaces;
using Day4.Task2.Models;
using System.Text.RegularExpressions;

namespace Day4.Task2.Implementations;

public class CustomIsbnValidator : ICustomIsbnValidator
{
    public bool Validate(ISBNModel isbn)
    {
        if (isbn == null || string.IsNullOrWhiteSpace(isbn.Isbn))
            return false;

        return new Regex(ICustomIsbnValidator.Pattern).IsMatch(isbn.Isbn);
    }
}