namespace Lesson
{
  public interface IPersonActions
  {
    CreatePersonResponse Create(PersonRequest request);

    PersonRequest Get(Guid id);
  }
}
