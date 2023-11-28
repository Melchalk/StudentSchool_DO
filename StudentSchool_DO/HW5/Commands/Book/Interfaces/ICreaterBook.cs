using Microsoft.AspNetCore.Mvc;
using ServiceModels.Requests;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Common_interfaces;

namespace WebLibrary.Commands.Book.Interfaces;

public interface ICreaterBook : ICreater<CreateBookRequest, CreateBookResponse>
{
}
