using Presentation;

namespace Data.Repository;

public interface IBookRepository
{
    IList<Book> GetBooks();
}