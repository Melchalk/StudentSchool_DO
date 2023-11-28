using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ClientWebLibrary.Publishers.Book;

public class CreateBookMessagePublisher : IMessagePublisher<CreateBookRequest, CreateBookResponse>
{
    private readonly IRequestClient<CreateBookRequest> _requestClient;
    private readonly ILogger<CreateBookMessagePublisher> _logger;

    public CreateBookMessagePublisher(
      IRequestClient<CreateBookRequest> requestClient,
      ILogger<CreateBookMessagePublisher> logger)
    {
        _requestClient = requestClient;
        _logger = logger;
    }

    public async Task<CreateBookResponse> SendMessageAsync(CreateBookRequest request)
    {
        _logger.LogInformation("Starting sending book request from client");

        Response<CreateBookResponse> result = await _requestClient.GetResponse<CreateBookResponse>(request);

        _logger.LogInformation("Received request from server in client");

        return result.Message;
    }
}