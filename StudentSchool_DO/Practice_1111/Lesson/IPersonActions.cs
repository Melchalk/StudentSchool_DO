namespace Lesson
{
  public interface IPersonActions
  {
    CreatePersonResponse Create(PersonInfo request);

    PersonInfo Get(Guid id);
  }
}
