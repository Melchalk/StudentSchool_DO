using DbModels;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public class BookMapper : IBookMapper
{
    public DbBook Map(BookRequest bookRequest)
    {
        DbBook book = new()
        {
            Title = bookRequest.Title,
            Author = bookRequest.Author,
            NumberPages = bookRequest.NumberPages,
            YearPublishing = bookRequest.YearPublishing,
            CityPublishing = bookRequest.CityPublishing,
            HallNo = bookRequest.HallNo
        };

        return book;
    }

    public BookRequest Map(DbBook book)
    {
        BookRequest bookRequest = new()
        {
            Title = book.Title,
            Author = book.Author,
            NumberPages = book.NumberPages,
            YearPublishing = book.YearPublishing,
            CityPublishing = book.CityPublishing,
            HallNo = book.HallNo
        };

        return bookRequest;
    }
}