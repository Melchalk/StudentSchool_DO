using DbModels;
using WebLibrary.Requests;
using WebLibrary.Responses;

namespace WebLibrary.Mappers.Reader;

public interface IReaderMapper
{
    DbReader Map(CreateReaderRequest readerRequest);

    GetReaderResponse Map(DbReader dbReader);
}
