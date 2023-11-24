using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.Mappers.Reader;

public interface IReaderMapper
{
    DbReader Map(CreateReaderRequest readerRequest);

    GetReaderResponse Map(DbReader dbReader);
}
