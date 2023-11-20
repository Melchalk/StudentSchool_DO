using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Mappers.Issue;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers.Reader;

public interface IReaderMapper
{
    DbReader Map([FromServices] IIssueMapper issueMapper, ReaderRequest readerRequest);

    ReaderRequest Map([FromServices] IIssueMapper issueMapper, DbReader dbReader);
}
