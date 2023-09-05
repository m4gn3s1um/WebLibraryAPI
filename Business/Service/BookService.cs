using Data.Repository;
using Models;

namespace Business.Service;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public IList<Book> GetBooks()
    {
        return _bookRepository.GetBooks();
    }

    public Book GetBook(Guid id)
    {
        return _bookRepository.GetBook(id);
    }

    public bool BookExists(Guid id)
    {
        return _bookRepository.BookExists(id);
    }

    public Book UpdateBook(Guid id, Book book)
    {
        return _bookRepository.UpdateBook(id, book);
    }

    public void DeleteBook(Guid id)
    {
        _bookRepository.DeleteBook(id);
    }

    public Book CreateBook(Book book)
    {
        return _bookRepository.CreateBook(book);
    }

    public IList<Book> GetAvailableBooks()
    {
        return _bookRepository.GetAvailableBooks();
    }
}