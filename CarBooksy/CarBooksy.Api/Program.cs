using CarBooksy.Api.Middlewares;
using CarBooksy.Application;
using CarBooksy.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext<ApplicationDbContext>();

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