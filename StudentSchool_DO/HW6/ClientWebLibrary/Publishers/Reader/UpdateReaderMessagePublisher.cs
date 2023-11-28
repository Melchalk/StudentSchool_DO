using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ClientWebLibrary.Publishers.Reader;

public class UpdateReaderMessagePublisher : IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse>
{
    private readonly IRequestClient<UpdateReaderRequest> _requestClient;
    private readonly ILogger<UpdateReaderMessagePublisher> _logger;

    public UpdateReaderMessagePublisher(
      IRequestClient<UpdateReaderRequest> requestClient,
      ILogger<UpdateReaderMessagePublisher> logger)
    {
        _requestClient = requestClient;
        _logger = logger;
    }

    public async Task<UpdateReaderResponse> SendMessageAsync(UpdateReaderRequest request)
    {
        _logger.LogInformation("Starting sending reader request from client");

        Response<UpdateReaderResponse> result = await _requestClient.GetResponse<UpdateReaderResponse>(request);

        _logger.LogInformation("Received request from server in client");

        return result.Message;
    }
}