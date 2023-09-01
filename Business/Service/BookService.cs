using Data.Repository;
using Presentation;

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
}