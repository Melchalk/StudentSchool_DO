using MassTransit;
using ServiceModels.Requests;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers;

public class CreateBookConsumer : IConsumer<CreateBookRequest>
{
    private readonly ICreaterBook _command;
    private readonly ILogger<CreateBookConsumer> _logger;

    public CreateBookConsumer(
      ICreaterBook command,
      ILogger<CreateBookConsumer> logger)
    {
        _command = command;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CreateBookRequest> context)
    {
        _logger.LogInformation("Received book request from client in server");

        CreateBookResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);

        _logger.LogInformation("Responded to client in server");
    }
}
