using MassTransit;
using Provider.Repositories;
using WebLibrary.Commands.Book.Book_commands;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Commands.Reader.Reader_commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Mappers.Issue;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();

builder.Services.AddTransient<ICreaterReader, CreaterReader>();
builder.Services.AddTransient<IReaderReader, ReaderReader>();
builder.Services.AddTransient<IUpdaterReader, UpdaterReader>();
builder.Services.AddTransient<IDeleterReader, DeleterReader>();

builder.Services.AddTransient<ICreateBookRequestValidator, CreateBookRequestValidator>();
builder.Services.AddTransient<IBookMapper, BookMapper>();

builder.Services.AddTransient<ICreaterBook, CreaterBook>();
builder.Services.AddTransient<IReaderBook, ReaderBook>();
builder.Services.AddTransient<IUpdaterBook, UpdaterBook>();
builder.Services.AddTransient<IDeleterBook, DeleterBook>();

builder.Services.AddTransient<ICreateReaderRequestValidator, CreateReaderRequestValidator>();
builder.Services.AddTransient<IReaderMapper, ReaderMapper>();

builder.Services.AddTransient<IIssueMapper, IssueMapper>();

try
{
    builder.Services.AddMassTransit(x =>
    {
        x.AddConsumers(typeof(Program).Assembly);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
