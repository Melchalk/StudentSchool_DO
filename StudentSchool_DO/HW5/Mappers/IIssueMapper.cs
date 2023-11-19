using DbModels;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public interface IIssueMapper
{
    DbIssue Map(IssueRequest issueRequest);

    IssueRequest Map(DbIssue dbIssue);
}
