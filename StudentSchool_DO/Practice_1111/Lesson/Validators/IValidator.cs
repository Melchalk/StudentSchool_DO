namespace Lesson.Validators
{
  public interface IValidator<T> where T : class
  {
    ValidationResult Validate(T request);
  }
}
