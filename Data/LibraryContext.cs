using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Borrower> Borrowers { get; set; } = null!;
}