using Models;

namespace Data.Repository;

public class BookRepository : IBookRepository
{
    private List<Book> books = new List<Book>
    {
        new Book("Moby dick"),
        new Book("The Hobbit"),
        new Book("Sleeping giants", false)
    };

    public IList<Book> GetBooks()
    {
        return books;
    }

    public Book GetBook(Guid id)
    {
        return books.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public bool BookExists(Guid id)
    {
        return books.Any(x => x.Id == id);
    }

    public Book UpdateBook(Guid id, Book book)
    {
        var bookToUpdate = GetBook(id);
        bookToUpdate.Name = book.Name;
        bookToUpdate.Available = book.Available;
        return bookToUpdate;
    }

    public void DeleteBook(Guid id)
    {
        books.Remove(GetBook(id));
    }

    public Book CreateBook(Book book)
    {
        books.Add(book);
        return book;
    }

    public IList<Book> GetAvailableBooks()
    {
        return books.Where(x => x.Available).ToList();
    }
}