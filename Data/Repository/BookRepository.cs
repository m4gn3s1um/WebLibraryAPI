using Models;

namespace Data.Repository;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public IList<Book> GetBooks()
    {
        return _context.Books.ToList();
    }

    public Book GetBook(Guid id)
    {
        return _context.Books.Find(id);
    }

    public bool BookExists(Guid id)
    {
        return _context.Books.Any(x => x.Id == id);
    }

    public Book UpdateBook(Guid id, Book book)
    {
        var bookToUpdate = GetBook(id);
        bookToUpdate.Name = book.Name;
        bookToUpdate.Available = book.Available;
        _context.SaveChanges();
        return bookToUpdate;
    }

    public void DeleteBook(Guid id)
    {
        _context.Books.Remove(GetBook(id));
        _context.SaveChanges();
    }

    public Book CreateBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public IList<Book> GetAvailableBooks()
    {
        return _context.Books.Where(x => x.Available).ToList();
    }
}