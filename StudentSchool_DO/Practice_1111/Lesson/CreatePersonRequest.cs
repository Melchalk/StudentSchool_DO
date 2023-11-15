namespace Lesson;

public record CreatePersonRequest
{

  public string Name {  get; set; }

  public int Age {  get; set; }

  public bool HasJob {  get; set; }
}
