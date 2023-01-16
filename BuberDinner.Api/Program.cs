using System.Globalization;
using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure()
    .AddPersistence(builder.Configuration, builder.Environment.IsDevelopment());

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
