using FluentValidation;
using WebLibrary.ModelRequest;

namespace WebLibrary.Validators;

public class CreateReaderRequestValidator : AbstractValidator<ReaderRequest>, ICreateReaderRequestValidator
{
    public CreateReaderRequestValidator()
    {
        RuleFor(request => request.Fullname)
          .NotEmpty()
          .WithMessage("Fullname should not be empty")
          .MaximumLength(50)
          .WithMessage("Fullname is too long");

        RuleFor(request => request.Age)
          .Must(a => a >= 14)
          .WithMessage("The age must be over 14");

        When(request => request.Age < 18 || request.RegistrationAddress is null, () =>
        {
            RuleFor(request => request.CanTakeBooks)
              .Must(a => a == false)
              .WithMessage("If age < 14 or registration address is unknown\nThe reader cannot take books");
        });
    }
}
