using Day4.Task2.Implementations;

namespace Day4.Tests.Task2.Fixtures;

public class BookFixture
{
    public Book ValidBook { get; }
    public Book AnotherBook { get; }

    public BookFixture()
    {
        ValidBook = new Book() 
        {
            ISBN = "9783161484100",
            Author = "Author A",
            Title = "Title A",
            Publishing = "Pub A",
            YearOfPublication = 2020,
            PagesCount = 300,
            Price = 29.99
        };

        AnotherBook = new Book()
        {
            ISBN = "9783161484101",
            Author = "Author B",
            Title = "Title B",
            Publishing = "Pub B",
            YearOfPublication = 2021,
            PagesCount = 200,
            Price = 19.99
        };
    }
}