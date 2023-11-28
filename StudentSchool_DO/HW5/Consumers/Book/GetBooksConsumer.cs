using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class GetBooksConsumer : IConsumer
{
    /*
    private readonly IReaderBook _command;

    public GetBooksConsumer(IReaderBook command)
    {
        _command = command;
    }

    public Task Consume()
    {
        List<GetBookResponse> actionResult = _command.Get();

        return Task.CompletedTask;
    }*/
}