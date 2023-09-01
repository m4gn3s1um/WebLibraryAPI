using Presentation;

namespace Business.Service;

public interface IBookService
{
    IList<Book> GetBooks();
}