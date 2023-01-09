#pragma warning disable CA1852
using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure()
    .AddPersistence(builder.Configuration, builder.Environment.IsDevelopment());

var app = builder.Build();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
