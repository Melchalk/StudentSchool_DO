using FluentValidation;

namespace Lesson;

public interface ICreatePersonRequestValidator : IValidator<PersonRequest>
{
}
