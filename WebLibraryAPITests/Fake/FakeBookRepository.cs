using Data.Repository;
using Models;

namespace WebLibraryAPITests.Fake;

public class FakeBookRepository : IBookRepository
{
    private List<Book> books = new List<Book>
    {
    };
    
    public IList<Book> GetBooks()
    {
        return books;
    }

    public Book GetBook(Guid id)
    {
        return books.FirstOrDefault(x => x.Id == id);
    }

    public bool BookExists(Guid id)
    {
        throw new NotImplementedException();
    }

    public Book UpdateBook(Guid id, Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public Book CreateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public IList<Book> GetAvailableBooks()
    {
        throw new NotImplementedException();
    }
}