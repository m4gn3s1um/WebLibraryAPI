namespace Models;

public class Borrower
{
    public Guid Id { get; }
    public string Name { get; set; }
    public IList<Book> BorrowedBooks { get; } = new List<Book>();

    public Borrower(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}