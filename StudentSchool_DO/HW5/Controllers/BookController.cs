using Microsoft.AspNetCore.Mvc;
using WebLibrary.BooksOptions;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public CreateBookResponse Create(
    [FromServices] IBookActions action,
    [FromBody] BookRequest request)
    {
        return action.Create(request);
    }

    [HttpGet]
    public BookRequest Get(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return action.Get(id);
    }

    [HttpPut]
    public BookRequest Update(
    [FromServices] IBookActions action,
    [FromQuery] Guid id,
    [FromBody] BookRequest request)
    {
        return action.Update(id, request);
    }

    [HttpDelete]
    public void Delete(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        action.Delete(id);
    }
}