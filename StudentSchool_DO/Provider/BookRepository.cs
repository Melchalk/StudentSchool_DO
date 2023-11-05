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

    public void CreateBook(DbBook book)
    {
        _context.Books.Add(book);

        _context.SaveChanges();
    }

    public void UpdateBook(Guid bookId, string attribute, string newValue) //придумать как сделать иначе
    {
        var book = _context.Books.FirstOrDefault(u => u.Id == bookId);

        if (attribute == "Title")
        {
            book.Title = newValue;
        }
        else if (attribute == "Author")
        {
            book.Author = newValue;
        }
        else if (attribute == "Number_pages")
        {
            book.Number_pages = int.Parse(newValue);
        }
        else if (attribute == "Year_publishing")
        {
            book.Year_publishing = int.Parse(newValue);
        }
        else if (attribute == "City_publishing")
        {
            book.City_publishing = newValue;
        }
        else if (attribute == "Hall_no")
        {
            book.Hall_no = int.Parse(newValue);
        }

        _context.SaveChanges();
    }

    public void DeleteBook(Guid bookId)
    {
        var book = _context.Books.FirstOrDefault(u => u.Id == bookId);

        _context.Remove(book);

        _context.SaveChanges();
    }
}
