using Microsoft.AspNetCore.Mvc;
using WebLibrary.Requests;

namespace WebLibrary.ReaderOptions;

public interface IReaderActions
{
    Task<IActionResult> Create(CreateReaderRequest request);

    Task<IActionResult> Get(Guid id);

    IActionResult Get();

    Task<IActionResult> Update(Guid id, CreateReaderRequest request);

    Task<IActionResult> Delete(Guid id);
}