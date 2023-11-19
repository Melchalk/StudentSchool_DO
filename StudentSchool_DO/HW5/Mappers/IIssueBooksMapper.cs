using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public interface IIssueBooksMapper
{
    DbIssueBooks Map(IssueBooksRequest issueBooksRequest);

    IssueBooksRequest Map(DbIssueBooks dbIssueBooks);
}
