namespace Day3.Task1_3.Interfaces;

/// <summary>
///     Transformer interface.
/// </summary>
/// <typeparam name="TSource">The type of the source.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
public interface ITransformer<TSource, TResult>
{
    TResult Transform(TSource element);
}