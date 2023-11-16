namespace Lesson
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      builder.Services.AddTransient<IPersonActions, PersonActions>();
      builder.Services.AddTransient<ICreatePersonRequestValidator, CreatePersonRequestValidator>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.

      app.MapControllers();

      app.Run();
    }
  }
}