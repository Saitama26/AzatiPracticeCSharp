using Day4.Task2.Interfaces;
using Day4.Task2.Models;

namespace Day4.Task2.Implementations;

public class CustomIsbnValidatorAdapter : IIsbnValidator
{
    private readonly ICustomIsbnValidator _customIsbnValidator;

    public CustomIsbnValidatorAdapter(ICustomIsbnValidator customIsbnValidator)
    {
        _customIsbnValidator = customIsbnValidator;
    }

    public bool Validate(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            return false;

        var model = new ISBNModel { Isbn = isbn };
        return _customIsbnValidator.Validate(model);
    }
}