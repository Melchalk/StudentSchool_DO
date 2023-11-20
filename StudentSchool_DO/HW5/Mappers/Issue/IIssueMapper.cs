using DbModels;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers.Issue;

public interface IIssueMapper
{
    DbIssue Map(IssueRequest issueRequest);

    IssueRequest Map(DbIssue dbIssue);
}
