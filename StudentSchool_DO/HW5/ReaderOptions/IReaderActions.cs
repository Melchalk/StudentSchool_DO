using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.ReaderOptions;

public interface IReaderActions
{
    CreateReaderResponse Create(ReaderRequest request);

    ReaderRequest Get(Guid id);

    ReaderRequest Update(Guid id, ReaderRequest request);

    void Delete(Guid id);
}