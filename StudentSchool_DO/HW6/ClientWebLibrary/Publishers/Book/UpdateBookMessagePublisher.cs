using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ClientWebLibrary.Publishers.Book;

public class UpdateBookMessagePublisher : IMessagePublisher<UpdateBookRequest, UpdateBookResponse>
{
    private readonly IRequestClient<UpdateBookRequest> _requestClient;
    private readonly ILogger<UpdateBookMessagePublisher> _logger;

    public UpdateBookMessagePublisher(
      IRequestClient<UpdateBookRequest> requestClient,
      ILogger<UpdateBookMessagePublisher> logger)
    {
        _requestClient = requestClient;
        _logger = logger;
    }

    public async Task<UpdateBookResponse> SendMessageAsync(UpdateBookRequest request)
    {
        _logger.LogInformation("Starting sending book request from client");

        Response<UpdateBookResponse> result = await _requestClient.GetResponse<UpdateBookResponse>(request);

        _logger.LogInformation("Received request from server in client");

        return result.Message;
    }
}