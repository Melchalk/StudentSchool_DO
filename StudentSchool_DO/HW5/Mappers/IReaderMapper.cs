using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public interface IReaderMapper
{
    DbReader Map([FromServices] IIssueMapper issueMapper, ReaderRequest readerRequest);

    ReaderRequest Map([FromServices] IIssueMapper issueMapper, DbReader dbReader);
}
