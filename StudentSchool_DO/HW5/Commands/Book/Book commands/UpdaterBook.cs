﻿using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class UpdaterBook : BookActions, IUpdaterBook
{
    public UpdaterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
    : base(bookRepository, validator, mapper)
    {
    }

    public async Task<UpdateBookResponse> UpdateAsync(UpdateBookRequest updateRequest)
    {
        CreateBookRequest request = updateRequest.CreateBookRequest;
        Guid id = updateRequest.Id;

        UpdateBookResponse bookResponse = new();

        if (await _bookRepository.GetAsync(id) is null)
        {
            bookResponse.Errors = new()
            {
                NOT_FOUND
            };

            return bookResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            bookResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return bookResponse;
        }

        DbBook book = _mapper.Map(request);
        book.Id = id;

        await _bookRepository.UpdateAsync(book);

        bookResponse.Result = true;

        return bookResponse;
    }
}