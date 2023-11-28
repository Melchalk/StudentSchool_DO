using DbModels;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class ReaderBook : BookActions, IReaderBook
{
    public ReaderBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
    : base(bookRepository, validator, mapper)
    {
    }

    public List<GetBookResponse> Get()
    {
        List<DbBook> dbBooks = _bookRepository.Get().ToList();

        List<GetBookResponse> bookResponse = dbBooks.Select(u => _mapper.Map(u)).ToList();

        return bookResponse;
    }

    public async Task<GetBookResponse?> GetAsync(GetBookRequest request)
    {
        DbBook? book = await _bookRepository.GetAsync(request.Id);

        if (book is null)
        {
            return null;
        }

        return _mapper.Map(book);
    }
}