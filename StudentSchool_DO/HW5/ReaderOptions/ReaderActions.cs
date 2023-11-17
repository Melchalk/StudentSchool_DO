using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;
using WebLibrary.Validators;

namespace WebLibrary.ReaderOptions;

public class ReaderActions : IReaderActions
{
    private readonly CreateReaderResponse response = new();
    private readonly ReaderRepository _readerRepository = new();

    private readonly ICreateReaderRequestValidator _validator;
    private readonly IReaderMapper _mapper;

    public ReaderActions(ICreateReaderRequestValidator validator, IReaderMapper mapper)
    {
        _validator = validator;
        _mapper = mapper;
    }

    public CreateReaderResponse Create(ReaderRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var id = Guid.NewGuid();

            var reader = _mapper.Map(request);
            reader.Id = id;

            _readerRepository.Add(reader);

            response.Id = id;
        }

        return response;
    }

    public ReaderRequest Get(Guid id)
    {
        return _mapper.Map(_readerRepository.Get(id));
    }

    public ReaderRequest Update(Guid id, ReaderRequest request)
    {
        var reader = _mapper.Map(request);
        reader.Id = id;

        _readerRepository.Update(reader);

        return _mapper.Map(_readerRepository.Get(id));
    }

    public void Delete(Guid id)
    {
        DbReader reader = _readerRepository.Get(id);

        if (reader is not null)
        {
            _readerRepository.Delete(reader);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}