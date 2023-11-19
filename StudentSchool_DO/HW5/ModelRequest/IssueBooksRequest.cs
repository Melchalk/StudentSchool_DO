namespace WebLibrary.ModelRequest;

public class IssueBooksRequest
{
    public Guid IssueId { get; set; }
    public Guid BookId { get; set; }
}
