using DbModels;
using ServiceModels.Requests;
using ServiceModels.Responses.Reader;

namespace WebLibrary.Mappers.Reader;

public interface IReaderMapper
{
    DbReader Map(CreateReaderRequest readerRequest);

    GetReaderResponse Map(DbReader dbReader);
}
