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

    public List<GetBookResponse> Get()
    {
        List<DbBook> dbBooks = _bookRepository.Get().ToList();

        List<GetBookResponse> bookResponse = dbBooks.Select(u => _mapper.Map(u)).ToList();

        return bookResponse;
    }

    public async Task<GetBookResponse> GetAsync(GetBookRequest request)
    {
        DbBook? book = await _bookRepository.GetAsync(request.Id);

        GetBookResponse bookResponse = new();

        if (book is null)
        {
            bookResponse.Error = NOT_FOUND;

            return bookResponse;
        }

        return _mapper.Map(book);
    }
}