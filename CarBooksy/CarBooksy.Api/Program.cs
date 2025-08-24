using CarBooksy.Api;
using CarBooksy.Api.Middlewares;
using CarBooksy.Application;
using CarBooksy.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddPersistanceServices()
    .AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();