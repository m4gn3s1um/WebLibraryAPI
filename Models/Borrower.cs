﻿namespace Models;

public class Borrower
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<Book> BorrowedBooks { get; set; } = new List<Book>();
    public int? PhoneNumber { get; set; }
}