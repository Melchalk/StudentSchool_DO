using DbModels;
using Provider.Repositories;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Book;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Common_interfaces;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class ReaderReader : ReaderActions, IReaderReader
{
    public ReaderReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
        : base(readerRepository, validator, mapper)
    {
    }

    public async Task<GetReadersResponse> GetAsync()
    {
        List<DbReader> dbReaders = await _readerRepository.GetAsync();

        GetReadersResponse readerResponse = new()
        {
            ReaderResponses = dbReaders.Select(_mapper.Map).ToList()
        };

        return readerResponse;
    }
    public async Task<GetReaderResponse> GetAsync(GetReaderRequest request)
    {
        DbReader? reader = await _readerRepository.GetAsync(request.Id);

        if (reader is null)
        {
            GetReaderResponse readerResponse = new()
            {
                Error = NOT_FOUND
            };

            return readerResponse;
        }

        return _mapper.Map(reader);
    }
}