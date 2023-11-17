using WebLibrary.ModelRequest;

namespace WebLibrary.ModelsResponses.BookResponses;

public class UpdateBookResponse
{
    public BookRequest? BookRequest { get; set; }
    public List<string>? Errors { get; set; }
}
