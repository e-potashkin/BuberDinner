using BuberDinner.Api;
using BuberDinner.Api.Common.Configurations;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogger);
builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Environment.IsDevelopment());

var app = builder.Build();

app.UseRateLimiter();
app.UseExceptionHandler("/error");
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapHealthChecks("/_health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapControllers();
app.UseOutputCache();

app.Run();
