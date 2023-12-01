using DbModels;
using Provider.Repositories;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
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

    public async Task<GetBooksResponse> GetAsync()
    {
        List<DbBook> dbBooks = await _bookRepository.GetAsync();

        GetBooksResponse bookResponse = new()
        {
            BookResponses = dbBooks.Select(_mapper.Map).ToList()
        };

        return bookResponse;
    }

    public async Task<GetBookResponse> GetAsync(GetBookRequest request)
    {
        DbBook? book = await _bookRepository.GetAsync(request.Id);

        if (book is null)
        {
            GetBookResponse bookResponse = new()
            {
                Error = NOT_FOUND
            };

            return bookResponse;
        }

        return _mapper.Map(book);
    }
}