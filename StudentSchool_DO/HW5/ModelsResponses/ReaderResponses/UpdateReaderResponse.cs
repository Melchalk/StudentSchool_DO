using WebLibrary.ModelRequest;

namespace WebLibrary.ModelsResponses.ReaderResponses;

public class UpdateReaderResponse
{
    public ReaderRequest? ReaderRequest { get; set; }
    public List<string>? Errors { get; set; }
}
