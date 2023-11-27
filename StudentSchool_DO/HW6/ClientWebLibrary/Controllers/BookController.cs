using Microsoft.AspNetCore.Mvc;
using WebLibrary.BooksOptions;
using ClientWebLibrary.Requests;

namespace ClientWebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] IBookActions action,
    [FromBody] CreateBookRequest request)
    {
        return await action.CreateAsync(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetBookAsync(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return await action.GetAsync(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IBookActions action)
    {
        return action.Get();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IBookActions action,
    [FromQuery] Guid id,
    [FromBody] CreateBookRequest request)
    {
        return await action.UpdateAsync(id, request);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return await action.DeleteAsync(id);
    }
}