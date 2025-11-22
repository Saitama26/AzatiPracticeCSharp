using Day4.Task2.Implementations;

namespace Day4.Task2.Interfaces;

public interface IBookStorage
{
    IEnumerable<Book> Load();
    void Save(IEnumerable<Book> books);
}