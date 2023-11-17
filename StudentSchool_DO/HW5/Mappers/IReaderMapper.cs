using DbModels;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public interface IReaderMapper
{
    DbReader Map(ReaderRequest readerRequest);
}
