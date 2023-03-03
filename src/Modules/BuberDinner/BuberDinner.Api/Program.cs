using BuberDinner.Api;
using BuberDinner.Api.Common.Configurations;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogger);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment());

var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.UseRateLimiter();

app.Run();
