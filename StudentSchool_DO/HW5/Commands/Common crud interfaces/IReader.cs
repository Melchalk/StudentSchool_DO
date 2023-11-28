using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Commands.Common_interfaces;

public interface IReader<T, U>
{
    Task<U?> GetAsync(T request);

    List<U> Get();
}
