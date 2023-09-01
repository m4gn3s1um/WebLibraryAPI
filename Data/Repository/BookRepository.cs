using Presentation;

namespace Data.Repository;

public class BookRepository : IBookRepository
{
    public IList<Book> GetBooks()
    {
        return new List<Book>
        {
            new Book(1, "Moby dick"),
            new Book(2, "The Hobbit"),
            new Book(3, "Sleeping giants")
        };
    }
}