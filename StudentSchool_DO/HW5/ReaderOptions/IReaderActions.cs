using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.ReaderResponses;

namespace WebLibrary.ReaderOptions;

public interface IReaderActions
{
    IActionResult Create(ReaderRequest request);

    IActionResult Get(Guid id);

    IActionResult Get();

    IActionResult Update(Guid id, ReaderRequest request);

    IActionResult Delete(Guid id);
}