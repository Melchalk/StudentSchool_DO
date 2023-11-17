using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
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

            _bookRepository.Add(book);

            response.Id = id;
        }

        return response;
    }

    public BookRequest Get(Guid id)
    {
        return _mapper.Map(_bookRepository.Get(id));
    }


    public BookRequest Update(Guid id, BookRequest request)
    {
        var book = _mapper.Map(request);
        book.Id = id;

        _bookRepository.Update(book);

        return _mapper.Map(_bookRepository.Get(id));
    }

    public void Delete(Guid id)
    {
        DbBook book = _bookRepository.Get(id);

        if (book is not null)
        {
            _bookRepository.Delete(book);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
