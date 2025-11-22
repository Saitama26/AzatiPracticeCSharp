using Day4.Task2.Implementations;

namespace Day4.Tests.Task2.Fixtures;

public class BookServiceFixture
{
    // Return a fresh copy of the books list for each test to ensure test isolation
    public List<Book> GetBooks()
    {
        return new List<Book>
        {
            new Book { ISBN = "111", Author = "AuthorA", Title = "TitleA", Publishing = "PubA", YearOfPublication = 2000, PagesCount = 100, Price = 10.0 },
            new Book { ISBN = "222", Author = "AuthorB", Title = "TitleB", Publishing = "PubB", YearOfPublication = 2010, PagesCount = 200, Price = 20.0 },
            new Book { ISBN = "333", Author = "AuthorC", Title = "TitleC", Publishing = "PubC", YearOfPublication = 2020, PagesCount = 300, Price = 30.0 },
        };
    }
}