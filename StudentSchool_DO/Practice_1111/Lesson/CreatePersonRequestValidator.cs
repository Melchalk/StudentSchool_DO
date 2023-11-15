using FluentValidation;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Lesson;

public class CreatePersonRequestValidator : AbstractValidator<PersonInfo>, ICreatePersonRequestValidator
{
  public CreatePersonRequestValidator()
  {
    RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Имя должно быть указано!")
      .MaximumLength(3)
      .WithMessage("Имя слишком длинное!");

    RuleFor(request => request.Age)
      .Must(a => a >= 18)
      .WithMessage("Возраст должен быть больше 18");

    When(request => request.HasJob, () =>
    {
      RuleFor(request => request.Company)
        .NotEmpty();
    });
  }
}
