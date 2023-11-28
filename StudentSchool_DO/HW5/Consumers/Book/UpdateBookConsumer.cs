using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class UpdateBookConsumer : IConsumer<UpdateBookRequest>
{
    private readonly IUpdaterBook _command;
    private readonly ILogger<UpdateBookConsumer> _logger;

    public UpdateBookConsumer(
    IUpdaterBook command,
    ILogger<UpdateBookConsumer> logger)
    {
        _command = command;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<UpdateBookRequest> context)
    {
        _logger.LogInformation("Received book request from client in server");

        UpdateBookResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);

        _logger.LogInformation("Responded to client in server");
    }
}