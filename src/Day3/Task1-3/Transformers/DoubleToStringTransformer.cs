using Day2.Task1_2;
using Day3.Task1_3.Interfaces;

namespace Day3.Task1_3.Transformers;

public class DoubleToStringTransformer : ITransformer<double, string>
{
    private readonly string _language;

    public DoubleToStringTransformer(string language)
    {
        _language = language;
    }

    public string Transform(double element)
    {
        return Transformer.TransformToWords(element, _language);
    }
}
