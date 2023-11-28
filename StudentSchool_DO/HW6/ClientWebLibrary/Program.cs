using ClientWebLibrary.Publishers;
using ClientWebLibrary.Publishers.Book;
using ClientWebLibrary.Publishers.Reader;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ServiceModels.Requests.Book;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Book;
using ServiceModels.Responses.Reader;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<
  IMessagePublisher<CreateBookRequest, CreateBookResponse>,
  CreateBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateBookRequest, UpdateBookResponse>,
  UpdateBookMessagePublisher>();


builder.Services.AddScoped<
  IMessagePublisher<CreateReaderRequest, CreateReaderResponse>,
  CreateReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse>,
  UpdateReaderMessagePublisher>();

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
