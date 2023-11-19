using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public interface IBookMapper
{
    DbBook Map(BookRequest bookRequest);

    BookRequest Map([FromServices] IIssueBooksMapper issueBooksMapper, DbBook dbBook);
}
