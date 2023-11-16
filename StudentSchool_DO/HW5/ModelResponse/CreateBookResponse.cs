namespace WebLibrary.ModelResponse;

public class CreateBookResponse
{
    public Guid? Id { get; set; }
    public List<string> Errors { get; set; }
}
