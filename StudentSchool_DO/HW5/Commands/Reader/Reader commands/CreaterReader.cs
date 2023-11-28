using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using ServiceModels.Requests;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Common_interfaces;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class CreaterReader : ReaderActions, ICreaterReader
{
    public CreaterReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
    : base(readerRepository, validator, mapper)
    {
    }

    public async Task<Guid?> CreateAsync(CreateReaderRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return null;
        }

        DbReader reader = _mapper.Map(request);

        await _readerRepository.AddAsync(reader);

        return reader.Id;
    }

    Task<CreateReaderResponse> ICreater<CreateReaderRequest, CreateReaderResponse>.CreateAsync(CreateReaderRequest request)
    {
        throw new NotImplementedException();
    }
}
