using API.Extensions;
using API.Logger;
using Application;
using Application.Common;
using Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureEnvironmentVariables();
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);

builder.Services.AddControllers(config =>
{
  config.RespectBrowserAcceptHeader = true;
  config.ReturnHttpNotAcceptable = true;
}).AddJsonOptions(x =>
{
  //x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
  //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  //x.JsonSerializerOptions.WriteIndented = true;
  //x.JsonSerializerOptions.Converters.Add(new api.Utility.DateTimeConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
app.UseMiddleware<ApiKeyMiddleware>();
app.UseCors();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
