﻿using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
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

    public async Task<CreateReaderResponse> CreateAsync(CreateReaderRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateReaderResponse readerResponse = new();

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            readerResponse.Errors = errors;

            return readerResponse;
        }

        DbReader reader = _mapper.Map(request);

        await _readerRepository.AddAsync(reader);

        readerResponse.Id = reader.Id;

        return readerResponse;
    }
}
