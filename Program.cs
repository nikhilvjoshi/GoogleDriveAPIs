using DailyTaskService;
using Microsoft.Extensions.Logging;
using Serilog;


var builder = Host.CreateApplicationBuilder(args);

// Set up Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()  // You can adjust the level as needed
    .WriteTo.Console()           // Write logs to console (optional)
    .WriteTo.File("logs/myapp.log", rollingInterval: RollingInterval.Day) // Log to file with daily rotation
    .CreateLogger();

// Add Serilog to the DI container
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddHostedService<Worker>();
 
var host = builder.Build();
host.Run();
