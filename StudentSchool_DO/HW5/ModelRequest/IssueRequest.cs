namespace WebLibrary.ModelRequest;

public class IssueRequest
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public IList<IssueBooksRequest>? IssueBooks { get; set; }
    public ReaderRequest? Reader { get; set; }
}
