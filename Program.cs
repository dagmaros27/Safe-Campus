using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SafeCampus;
using SafeCampus.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.Configure<SafeCampusDatabaseSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


//registering services
builder.Services.AddSingleton<LaptopService>();
builder.Services.AddSingleton<ReportService>();
builder.Services.AddSingleton<TrackService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SafeCampus API", Description = "Secure your campus with technology", Version = "v1" });
});

var app = builder.Build();

// Configure logging to include request information
app.UseLoggingMiddleware();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SafeCampus API V1");
});

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "hello world");

app.Run();
