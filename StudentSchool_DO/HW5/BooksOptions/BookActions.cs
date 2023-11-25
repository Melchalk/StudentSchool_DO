using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using WebLibrary.Mappers.Book;
using WebLibrary.Requests;
using WebLibrary.Responses;
using WebLibrary.Validators;

namespace WebLibrary.BooksOptions;

public class BookActions : IBookActions
{
    private const string NOT_FOUND = "ID is not found";
    private const string DELETE = "The deletion was successful";

    private readonly IBookRepository _bookRepository;

    private readonly ICreateBookRequestValidator _validator;
    private readonly IBookMapper _mapper;

    public BookActions(
        IBookRepository bookRepository,
        ICreateBookRequestValidator validator,
        IBookMapper mapper)
    {
        _bookRepository = bookRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<IActionResult> CreateAsync(CreateBookRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbBook book = _mapper.Map(request);

        await _bookRepository.AddAsync(book);

        return new CreatedResult("Library.Books", book.Id);
    }

    public IActionResult Get()
    {
        List<DbBook> dbBooks = _bookRepository.Get().ToList();

        List<GetBookResponse> bookResponse = dbBooks.Select(u => _mapper.Map(u)).ToList();

        return new OkObjectResult(bookResponse);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        DbBook? book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        return new OkObjectResult(_mapper.Map(book));
    }

    public async Task<IActionResult> UpdateAsync(Guid id, CreateBookRequest request)
    {
        if (await _bookRepository.GetAsync(id) is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbBook book = _mapper.Map(request);
        book.Id = id;

        await _bookRepository.UpdateAsync(book);

        return new OkResult();
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        DbBook? book = await  _bookRepository.GetAsync(id);

        if (book is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        await _bookRepository.DeleteAsync(book);

        return new OkObjectResult(DELETE);
    }
}