using DbModels;
using ServiceModels.Requests;
using ServiceModels.Responses.Book;

namespace WebLibrary.Mappers.Book;

public interface IBookMapper
{
    DbBook Map(CreateBookRequest bookRequest);

    GetBookResponse Map(DbBook dbBook);
}
