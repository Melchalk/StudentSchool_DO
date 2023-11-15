using FluentValidation.Results;

namespace Lesson;

public class PersonActions : IPersonActions
{
  static Dictionary<Guid, PersonInfo> persons = new();
  CreatePersonResponse response = new();

  private readonly ICreatePersonRequestValidator _validator;

  public PersonActions(ICreatePersonRequestValidator validator)
  {
    _validator = validator;
  }

  public CreatePersonResponse Create(PersonInfo request)
  {
    ValidationResult result = _validator.Validate(request);

    if (!result.IsValid)
    {
      response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
    }
    else
    {
      var id = Guid.NewGuid();
      persons.Add(id, request);

      response.Id = id;
    }

    return response;
  }

  public PersonInfo Get(Guid id)
  {
    return persons[id];
  }
}
