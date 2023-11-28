using FluentValidation;
using ServiceModels.Requests;

namespace WebLibrary.Validators;

public interface ICreateReaderRequestValidator : IValidator<CreateReaderRequest>
{
}