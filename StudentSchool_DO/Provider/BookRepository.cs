using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class BookRepository
{
    private readonly OfficeDbContext _context = new();

    public DbBook? GetBook(Guid bookId)
    {
        return _context.Books.Where(u => u.Id == bookId).FirstOrDefault();
    }

    public DbSet<DbBook> GetBooks()
    {
        return _context.Books;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
