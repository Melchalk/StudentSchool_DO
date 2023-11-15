namespace Lesson.Validators
{
  public class PersonValidator : IValidator<PersonInfo>
  {
    private readonly Guid ValidOfficeId = Guid.Parse("E1FDB548-FBE0-4019-B889-6536CBB9F314");
    public ValidationResult Validate(PersonInfo request)
    {
      var validatioResult = new ValidationResult();

      if (request.Name.Length > 50)
      {
        validatioResult.Errors.Add("Name is too damn long.");
      }
      if (request.Age > 100)
      {
        validatioResult.Errors.Add("Age is too damn big.");
      }
      if (request.OfficeId != ValidOfficeId)
      {
        validatioResult.Errors.Add("Office with provided id doesn't exist.");
      }
      if (validatioResult.Errors.Count == 0)
      {
        validatioResult.IsValid = true;
      }

      return validatioResult;
    }
  }
}
