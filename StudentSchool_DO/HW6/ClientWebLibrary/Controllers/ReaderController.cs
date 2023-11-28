using ClientWebLibrary.Publishers;
using Microsoft.AspNetCore.Mvc;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ClientWebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] IMessagePublisher<CreateReaderRequest, CreateReaderResponse> messagePublisher,
    [FromBody] CreateReaderRequest request)
    {
        CreateReaderResponse readerResponse = await messagePublisher.SendMessageAsync(request);

        if (readerResponse.Id is null)
        {
            return BadRequest(readerResponse.Errors);
        }

        return Created("Readers", readerResponse.Id);
    }

    /*
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
    */

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse> messagePublisher,
    [FromQuery] Guid id,
    [FromBody] CreateReaderRequest request)
    {
        UpdateReaderRequest updateRequest = new() { Id = id, CreateReaderRequest = request };

        UpdateReaderResponse readerResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (readerResponse.Result == false)
        {
            return BadRequest(readerResponse.Errors);
        }

        return Ok();
    }

    /*
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return await action.Delete(id);
    }*/
}