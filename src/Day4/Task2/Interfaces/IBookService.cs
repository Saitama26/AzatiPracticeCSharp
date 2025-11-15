using Day4.Task2.enums;
using Day4.Task2.Implementations;

namespace Day4.Task2.Interfaces;

public interface IBookService
{
    public void Add(Book book);
    public void Remove(Book book);
    public IEnumerable<Book> FindByTag(BookTag tag, object value);
    public IEnumerable<Book> SortBy(BookTag tag);
}