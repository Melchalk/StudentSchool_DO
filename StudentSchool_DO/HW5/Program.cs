using WebLibrary.BooksOptions;
using WebLibrary.ReaderOptions;
using WebLibrary.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IBookActions, BookActions>();
builder.Services.AddTransient<ICreateBookRequestValidator, CreateBookRequestValidator>();

builder.Services.AddTransient<IReaderActions, ReaderActions>();
builder.Services.AddTransient<ICreateReaderRequestValidator, CreateReaderRequestValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
