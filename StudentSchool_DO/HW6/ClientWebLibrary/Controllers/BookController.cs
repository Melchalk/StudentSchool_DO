﻿using ClientWebLibrary.Publishers;
using Microsoft.AspNetCore.Mvc;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ClientWebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] IMessagePublisher<CreateBookRequest, CreateBookResponse> messagePublisher,
    [FromBody] CreateBookRequest request)
    {
        CreateBookResponse bookResponse = await messagePublisher.SendMessageAsync(request);

        if (bookResponse.Id is null)
        {
            return BadRequest(bookResponse.Errors);
        }

        return Created("Books", bookResponse.Id);
    }
    /*
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
    */
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IMessagePublisher<UpdateBookRequest, UpdateBookResponse> messagePublisher,
    [FromQuery] Guid id,
    [FromBody] CreateBookRequest request)
    {
        UpdateBookRequest updateRequest = new() { Id = id, CreateBookRequest = request };

        UpdateBookResponse bookResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (bookResponse.Result == false)
        {
            return BadRequest(bookResponse.Errors);
        }

        return Ok();
    }
    /*
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return await action.DeleteAsync(id);
    }*/
}