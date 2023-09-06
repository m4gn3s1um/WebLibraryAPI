namespace Models;

public class BorrowRecord
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid BorrowerId { get; set; }
    public Borrower Borrower { get; set; }
    public DateTime BorrowedOn { get; set; }
}