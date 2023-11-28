using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;

namespace WebLibrary.Consumers.Reader;

public class CreateReaderConsumer : IConsumer<CreateReaderRequest>
{
    private readonly ICreaterReader _command;
    private readonly ILogger<CreateReaderConsumer> _logger;

    public CreateReaderConsumer(
      ICreaterReader command,
      ILogger<CreateReaderConsumer> logger)
    {
        _command = command;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CreateReaderRequest> context)
    {
        _logger.LogInformation("Received reader request from client in server");

        CreateReaderResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);

        _logger.LogInformation("Responded to client in server");
    }
}