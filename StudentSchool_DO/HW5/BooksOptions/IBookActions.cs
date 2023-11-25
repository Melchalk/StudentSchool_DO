using Microsoft.AspNetCore.Mvc;
using WebLibrary.Requests;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    Task<IActionResult> CreateAsync(CreateBookRequest request);

    Task<IActionResult> GetAsync(Guid id);

    IActionResult Get();

    Task<IActionResult> UpdateAsync(Guid id, CreateBookRequest request);

    Task<IActionResult> DeleteAsync(Guid id);
}