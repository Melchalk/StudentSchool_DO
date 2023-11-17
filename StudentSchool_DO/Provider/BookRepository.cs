using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

    public void AddBook(DbBook book)
    {
        _context.Books.Add(book);

        _context.SaveChanges();
    }

    public void DeleteBook(DbBook book)
    {
        _context.Books.Remove(book);

        _context.SaveChanges();
    }

    public void UpdateBook(DbBook book, PropertyInfo property, string newValue)
    {
        if (int.TryParse(newValue, out var value))
        {
            property?.SetValue(book, value);
        }
        else
        {
            property?.SetValue(book, newValue);
        }

        _context.SaveChanges();
    }

    public DbBook UpdateBook(DbBook? book)
    {
        DbBook oldBook = GetBook(book.Id);

        foreach (PropertyInfo property in typeof(DbBook).GetProperties())
        {
            property?.SetValue(oldBook, property.GetValue(book));
        }

        _context.SaveChanges();

        return GetBook(book.Id);
    }
}