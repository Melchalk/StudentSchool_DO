﻿using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class UpdaterReader : ReaderActions, IUpdaterReader
{
    public UpdaterReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
        : base(readerRepository, validator, mapper)
    {
    }

    public async Task<UpdateReaderResponse> UpdateAsync(UpdateReaderRequest updateRequest)
    {
        CreateReaderRequest request = updateRequest.CreateReaderRequest;
        Guid id = updateRequest.Id;

        UpdateReaderResponse readerResponse = new();

        if (await _readerRepository.GetAsync(id) is null)
        {
            readerResponse.Errors = new()
            {
                NOT_FOUND
            };

            return readerResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            readerResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return readerResponse;
        }

        DbReader reader = _mapper.Map(request);
        reader.Id = id;

        await _readerRepository.UpdateAsync(reader);

        readerResponse.Result = true;

        return readerResponse;
    }
}