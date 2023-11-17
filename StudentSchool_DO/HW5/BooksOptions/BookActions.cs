using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.BookResponses;
using WebLibrary.Validators;

namespace WebLibrary.BooksOptions;

public class BookActions : IBookActions
{
    private const string NOT_FOUND = "ID is not found";
    private const string DELETE = "The deletion was successful";

    private readonly CreateBookResponse createResponse = new();
    private readonly GetBookResponse getResponse = new();
    private readonly UpdateBookResponse updateResponse = new();
    private readonly DeleteBookResponse deleteResponse = new();

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
            createResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var id = Guid.NewGuid();

            var book = _mapper.Map(request);
            book.Id = id;

            _bookRepository.Add(book);

            createResponse.Id = id;
        }

        return createResponse;
    }

    public GetBookResponse Get(Guid id)
    {
        DbBook? book = _bookRepository.Get(id);

        if (book is null)
        {
            getResponse.Error = NOT_FOUND;
        }
        else
        {
            getResponse.BookRequest = _mapper.Map(book);
        }

        return getResponse;
    }

    public UpdateBookResponse Update(Guid id, BookRequest request)
    {
        if (_bookRepository.Get(id) is null)
        {
            updateResponse.Errors = new() { NOT_FOUND };
        }
        else
        {
            ValidationResult result = _validator.Validate(request);

            if (!result.IsValid)
            {
                updateResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var book = _mapper.Map(request);
                book.Id = id;

                _bookRepository.Update(book);

                updateResponse.BookRequest = _mapper.Map(_bookRepository.Get(id));
            }
        }

        return updateResponse;
    }

    public DeleteBookResponse Delete(Guid id)
    {
        DbBook? book = _bookRepository.Get(id);

        if (book is not null)
        {
            _bookRepository.Delete(book);
            deleteResponse.Result = DELETE;
        }
        else
        {
            deleteResponse.Result = NOT_FOUND;
        }

        return deleteResponse;
    }
}
