using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Backend.Common;
using Backend.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ServicebusProvider>();

var app = builder.Build();

// Set up Azure resources
ResourceManager.RunSetUpScript();

app.Lifetime.ApplicationStopping.Register(() =>
{
    // Clean up Azure resources
    ResourceManager.cleanUpScript();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
