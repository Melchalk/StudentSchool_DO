using DbModels;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Mappers.Issue;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers.Reader;

public class ReaderMapper : IReaderMapper
{
    public DbReader Map(
        [FromServices] IIssueMapper issueMapper,
        ReaderRequest readerRequest)
    {
        DbReader reader = new()
        {
            Id = Guid.NewGuid(),
            Fullname = readerRequest.Fullname,
            Telephone = readerRequest.Telephone,
            RegistrationAddress = readerRequest.RegistrationAddress,
            Age = readerRequest.Age,
            CanTakeBooks = readerRequest.CanTakeBooks,
            Issue = issueMapper.Map(readerRequest.Issue)
        };

        return reader;
    }

    public ReaderRequest Map(
        [FromServices] IIssueMapper issueMapper,
        DbReader reader)
    {
        ReaderRequest readerRequest = new()
        {
            Fullname = reader.Fullname,
            Telephone = reader.Telephone,
            RegistrationAddress = reader.RegistrationAddress,
            Age = reader.Age,
            Issue = issueMapper.Map(reader.Issue)
        };

        return readerRequest;
    }
}