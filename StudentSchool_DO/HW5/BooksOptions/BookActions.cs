using DbModels;
using FluentValidation.Results;
using Provider;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;
using WebLibrary.Validators;

namespace WebLibrary.BooksOptions;

public class BookActions : IBookActions
{
    private readonly CreateBookResponse response = new();
    private readonly BookRepository _bookRepository = new();

    private readonly ICreateBookRequestValidator _validator;
    private readonly IBookMapper _mapper;

    public BookActions(ICreateBookRequestValidator validator, IBookMapper mapper)
    {
        _validator = validator;
        _mapper = mapper;
    }

    public CreateBookResponse Create(BookRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var id = Guid.NewGuid();

            var book = _mapper.Map(request);
            book.Id = id;

            _bookRepository.AddBook(book);

            response.Id = id;
        }

        return response;
    }

    public BookRequest Get(Guid id)
    {
        return _mapper.Map(_bookRepository.GetBook(id));
    }


    public BookRequest Update(Guid id, BookRequest request)
    {
        var book = _mapper.Map(request);
        book.Id = id;

        _bookRepository.UpdateBook(book);

        return _mapper.Map(_bookRepository.GetBook(id));
    }

    public void Delete(Guid id)
    {
        DbBook book = _bookRepository.GetBook(id);

        if (book is not null)
        {
            _bookRepository.DeleteBook(book);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
