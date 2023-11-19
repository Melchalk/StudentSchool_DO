using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public class IssueBooksMapper : IIssueBooksMapper
{
    public DbIssueBooks Map(IssueBooksRequest issueBooksRequest)
    {
        DbIssueBooks dbIssueBooks = new()
        {
            IssueId = issueBooksRequest.IssueId,
            BookId = issueBooksRequest.BookId,
        };

        return dbIssueBooks;
    }

    public IssueBooksRequest Map(DbIssueBooks dbIssueBooks)
    {
        IssueBooksRequest issueBooksRequest = new()
        {
            IssueId = dbIssueBooks.IssueId,
            BookId = dbIssueBooks.BookId,
        };

        return issueBooksRequest;
    }
}
