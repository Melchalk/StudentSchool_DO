using ClientWebLibrary.Publishers;
using ClientWebLibrary.Publishers.Book;
using ClientWebLibrary.Publishers.Reader;
using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Book;
using ServiceModels.Responses.Reader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Book
builder.Services.AddScoped<
  IMessagePublisher<CreateBookRequest, CreateBookResponse>,
  CreateBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetBookRequest, GetBookResponse>,
  GetBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetBooksRequest, GetBooksResponse>,
  GetBooksMessagePublisher>();


builder.Services.AddScoped<
  IMessagePublisher<UpdateBookRequest, UpdateBookResponse>,
  UpdateBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteBookRequest, DeleteBookResponse>,
  DeleteBookMessagePublisher>();

//Reader
builder.Services.AddScoped<
  IMessagePublisher<CreateReaderRequest, CreateReaderResponse>,
  CreateReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetReaderRequest, GetReaderResponse>,
  GetReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetReadersRequest, GetReadersResponse>,
  GetReadersMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse>,
  UpdateReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteReaderRequest, DeleteReaderResponse>,
  DeleteReaderMessagePublisher>();

try
{
    builder.Services.AddMassTransit(x =>
    {
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost");
            cfg.ConfigureEndpoints(context);
        });
    });
}
catch (Exception)
{
    throw new Exception("Failed to connect to rabbitmq");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
