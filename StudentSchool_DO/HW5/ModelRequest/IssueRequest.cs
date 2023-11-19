namespace WebLibrary.ModelRequest;

public class IssueRequest
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }
}
