using Microsoft.AspNetCore.Mvc;

namespace Lesson.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
  [HttpPost]
  public CreatePersonResponse Create(
    [FromServices] IPersonActions action,
    [FromBody] PersonRequest request)
  {
    return action.Create(request);
  }
}
