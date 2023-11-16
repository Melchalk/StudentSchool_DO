using System;

namespace WebLibrary;

public interface IValidator<T> where T : class
{
    ValidationResult Validate(T request);
}
