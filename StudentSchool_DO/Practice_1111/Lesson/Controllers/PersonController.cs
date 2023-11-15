using Microsoft.AspNetCore.Mvc;

namespace Lesson.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
  [HttpPost]
  public CreatePersonResponse Create(
    [FromServices] IPersonActions action,
    [FromBody] PersonInfo request)
  {
    return action.Create(request);
  }
}
