using FluentValidation;
using ServiceModels.Requests;

namespace WebLibrary.Validators;

public interface ICreateBookRequestValidator : IValidator<CreateBookRequest>
{
}