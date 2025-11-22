using Day4.Task2.enums;
using Day4.Task2.Implementations;

namespace Day4.Task2.Interfaces;

public interface IBookService
{
    void Add(Book book);
    void Remove(Book book);
    IEnumerable<Book> FindByTag(BookTag tag, object value);
    IEnumerable<Book> SortBy(BookTag tag);
}