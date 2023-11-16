using FluentValidation;
using WebLibrary.ModelRequest;

namespace WebLibrary.Validators;

public class CreateReaderRequestValidator : AbstractValidator<ReaderRequest>, ICreateReaderRequestValidator
{

}
