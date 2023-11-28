using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;

namespace WebLibrary.Consumers.Reader;

public class UpdateReaderConsumer : IConsumer<UpdateReaderRequest>
{
    private readonly IUpdaterReader _command;
    private readonly ILogger<UpdateReaderConsumer> _logger;

    public UpdateReaderConsumer(
    IUpdaterReader command,
    ILogger<UpdateReaderConsumer> logger)
    {
        _command = command;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<UpdateReaderRequest> context)
    {
        _logger.LogInformation("Received reader request from client in server");

        UpdateReaderResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);

        _logger.LogInformation("Responded to client in server");
    }
}