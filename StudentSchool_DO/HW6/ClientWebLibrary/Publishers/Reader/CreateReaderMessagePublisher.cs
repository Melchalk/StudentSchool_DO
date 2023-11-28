using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ClientWebLibrary.Publishers.Reader;

public class CreateReaderMessagePublisher : IMessagePublisher<CreateReaderRequest, CreateReaderResponse>
{
    private readonly IRequestClient<CreateReaderRequest> _requestClient;
    private readonly ILogger<CreateReaderMessagePublisher> _logger;

    public CreateReaderMessagePublisher(
      IRequestClient<CreateReaderRequest> requestClient,
      ILogger<CreateReaderMessagePublisher> logger)
    {
        _requestClient = requestClient;
        _logger = logger;
    }

    public async Task<CreateReaderResponse> SendMessageAsync(CreateReaderRequest request)
    {
        _logger.LogInformation("Starting sending Reader request from client");

        Response<CreateReaderResponse> result = await _requestClient.GetResponse<CreateReaderResponse>(request);

        _logger.LogInformation("Received request from server in client");

        return result.Message;
    }
}