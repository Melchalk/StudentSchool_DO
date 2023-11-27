using Microsoft.AspNetCore.Mvc;
using ClientWebLibrary.Requests;

namespace ClientWebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] IReaderActions action,
    [FromBody] CreateReaderRequest request)
    {
        return await action.Create(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetReaderAsync(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return await action.Get(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IReaderActions action)
    {
        return action.Get();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id,
    [FromBody] CreateReaderRequest request)
    {
        return await action.Update(id, request);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return await action.Delete(id);
    }
}