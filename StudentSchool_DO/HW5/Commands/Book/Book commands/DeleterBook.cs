﻿using DbModels;
using Provider.Repositories;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class DeleterBook : BookActions, IDeleterBook
{
    public DeleterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
        : base(bookRepository, validator, mapper)
    {
    }

    public async Task<DeleteBookResponse> DeleteAsync(DeleteBookRequest request)
    {
        DeleteBookResponse bookResponse = new();

        Guid id = request.Id;

        DbBook? book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            bookResponse.Error = NOT_FOUND;

            return bookResponse;
        }

        await _bookRepository.DeleteAsync(book);

        bookResponse.Result = true;

        return bookResponse;
    }
}
