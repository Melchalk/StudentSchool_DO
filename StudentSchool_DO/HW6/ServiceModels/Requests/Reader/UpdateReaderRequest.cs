using ServiceModels.Requests.Book;

namespace ServiceModels.Requests.Reader;

public class UpdateReaderRequest
{
    public Guid Id { get; set; }
    public CreateReaderRequest CreateReaderRequest { get; set; }
}
