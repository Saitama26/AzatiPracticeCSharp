using Day4.Task2.Models;

namespace Day4.Task2.Interfaces;

public interface ICustomIsbnValidator
{
    static readonly string Pattern = "^(?:ISBN(?:-13)?:? )?(?=[0-9]{13}$|" +
                                        "(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)97[89]" +
                                        "[- ]?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]$";

    bool Validate(ISBNModel isbn);
}