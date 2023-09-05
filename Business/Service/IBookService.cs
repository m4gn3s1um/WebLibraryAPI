using Models;

namespace Business.Service;

public interface IBookService
{
    IList<Book> GetBooks();
    Book? GetBook(Guid id);
    bool BookExists(Guid id);
    Book UpdateBook(Guid id, Book book);
    void DeleteBook(Guid id);
    Book CreateBook(Book book);
    IList<Book> GetAvailableBooks();
}