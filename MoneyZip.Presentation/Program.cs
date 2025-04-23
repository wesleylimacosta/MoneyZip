using MoneyZip.Application;
using MoneyZip.Infrastructure;
using MoneyZip.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddPresentationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
app.UsePresentationMiddleware(app.Environment);

app.Run();