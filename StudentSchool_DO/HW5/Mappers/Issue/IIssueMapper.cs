using DbModels;
using ServiceModels.Requests;
using ServiceModels.Responses.Issue;

namespace WebLibrary.Mappers.Issue;

public interface IIssueMapper
{
    DbIssue Map(CreateIssueRequest issueRequest);

    GetIssueResponse? Map(DbIssue? dbIssue);
}
