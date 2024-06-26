using System.Globalization;

namespace Middleware_Practice;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddScoped<IMessageWriter, LoggingMessageWriter>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseRequestCulture();
        app.UseMyCustomMiddleware();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/", () => 
        {
            return CultureInfo.CurrentCulture.Name switch
            {
                "zh-TW" => "�A�n�A�@��!",
                "en-US" => "Hello World!",
                _ => "Hello World!",
            };
        });

        app.MapControllers();

        app.Run();
    }
}
