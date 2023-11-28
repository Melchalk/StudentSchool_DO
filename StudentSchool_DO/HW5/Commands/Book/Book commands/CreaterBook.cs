using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using ServiceModels.Requests;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class CreaterBook : BookActions, ICreaterBook
{
    public CreaterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
        : base(bookRepository, validator, mapper)
    {
    }

    public async Task<CreateBookResponse> CreateAsync(CreateBookRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateBookResponse bookResponse = new();

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            bookResponse.Errors = errors;

            return bookResponse;
        }

        DbBook book = _mapper.Map(request);

        await _bookRepository.AddAsync(book);

        bookResponse.Id = book.Id;

        return bookResponse;
    }
}
