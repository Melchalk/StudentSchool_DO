using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.ReaderResponses;
using WebLibrary.Validators;

namespace WebLibrary.ReaderOptions;

public class ReaderActions : IReaderActions
{
    private const string NOT_FOUND = "ID is not found";
    private const string DELETE = "The deletion was successful";

    private readonly CreateReaderResponse createResponse = new();
    private readonly GetReaderResponse getResponse = new();
    private readonly UpdateReaderResponse updateResponse = new();
    private readonly DeleteReaderResponse deleteResponse = new();

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
            createResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var id = Guid.NewGuid();

            var reader = _mapper.Map(request);
            reader.Id = id;

            _readerRepository.Add(reader);

            createResponse.Id = id;
        }

        return createResponse;
    }

    public GetReaderResponse Get(Guid id)
    {
        DbReader? reader = _readerRepository.Get(id);

        if (reader is null)
        {
            getResponse.Error = NOT_FOUND;
        }
        else
        {
            getResponse.ReaderRequest = _mapper.Map(reader);
        }

        return getResponse;
    }

    public UpdateReaderResponse Update(Guid id, ReaderRequest request)
    {
        if (_readerRepository.Get(id) is null)
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
                var reader = _mapper.Map(request);
                reader.Id = id;

                _readerRepository.Update(reader);

                updateResponse.ReaderRequest = _mapper.Map(_readerRepository.Get(id));
            }
        }

        return updateResponse;
    }

    public DeleteReaderResponse Delete(Guid id)
    {
        DbReader? reader = _readerRepository.Get(id);

        if (reader is not null)
        {
            _readerRepository.Delete(reader);
            deleteResponse.Result = DELETE;
        }
        else
        {
            deleteResponse.Result = NOT_FOUND;
        }

        return deleteResponse;
    }
}