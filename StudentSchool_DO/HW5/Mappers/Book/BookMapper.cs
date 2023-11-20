using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers.Book;

public class BookMapper : IBookMapper
{
    public DbBook Map(BookRequest bookRequest)
    {
        DbBook book = new()
        {
            Id = Guid.NewGuid(),
            Title = bookRequest.Title,
            Author = bookRequest.Author,
            NumberPages = bookRequest.NumberPages,
            YearPublishing = bookRequest.YearPublishing,
            CityPublishing = bookRequest.CityPublishing,
            HallNo = bookRequest.HallNo
        };

        return book;
    }

    public BookRequest Map([FromServices] IIssueBooksMapper issueBooksMapper, DbBook book)
    {
        List<IssueBooksRequest> issueBooksRequests = new();
        foreach (var issueBook in book.IssueBooks)
        {
            issueBooksRequests.Add(issueBooksMapper.Map(issueBook));
        }

        BookRequest bookRequest = new()
        {
            Title = book.Title,
            Author = book.Author,
            NumberPages = book.NumberPages,
            YearPublishing = book.YearPublishing,
            CityPublishing = book.CityPublishing,
            HallNo = book.HallNo,
            IssueBooks = issueBooksRequests
        };

        return bookRequest;
    }
}