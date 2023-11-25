using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using WebLibrary.Mappers.Reader;
using WebLibrary.Requests;
using WebLibrary.Responses;
using WebLibrary.Validators;

namespace WebLibrary.ReaderOptions;

public class ReaderActions : IReaderActions
{
    private const string NOT_FOUND = "ID is not found";
    private const string DELETE = "The deletion was successful";

    private readonly IReaderRepository _readerRepository;

    private readonly ICreateReaderRequestValidator _validator;
    private readonly IReaderMapper _mapper;

    public ReaderActions(
        IReaderRepository readerRepository,
        ICreateReaderRequestValidator validator,
        IReaderMapper mapper)
    {
        _readerRepository = readerRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<IActionResult> Create(CreateReaderRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbReader reader = _mapper.Map(request);

        await _readerRepository.AddAsync(reader);

        return new CreatedResult("Library.Readers", reader.Id);
    }

    public IActionResult Get()
    {
        List<DbReader> dbReaders = _readerRepository.Get().ToList();

        List<GetReaderResponse> readerResponse = dbReaders.Select(u => _mapper.Map(u)).ToList();

        return new OkObjectResult(readerResponse);
    }

    public async Task<IActionResult> Get(Guid id)
    {
        DbReader? reader = await  _readerRepository.GetAsync(id);

        if (reader is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        return new OkObjectResult(_mapper.Map(reader));
    }

    public async Task<IActionResult> Update(Guid id, CreateReaderRequest request)
    {
        if (await _readerRepository.GetAsync(id) is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbReader reader = _mapper.Map(request);
        reader.Id = id;

        await _readerRepository.UpdateAsync(reader);

        return new OkResult();
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        DbReader? reader = await _readerRepository.GetAsync(id);

        if (reader is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        await _readerRepository.DeleteAsync(reader);

        return new OkObjectResult(DELETE);
    }
}