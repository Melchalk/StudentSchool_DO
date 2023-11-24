using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    IActionResult Create(CreateBookRequest request);

    IActionResult Get(Guid id);

    IActionResult Get();

    IActionResult Update(Guid id, CreateBookRequest request);

    IActionResult Delete(Guid id);
}