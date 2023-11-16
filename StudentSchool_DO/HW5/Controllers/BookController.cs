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
}