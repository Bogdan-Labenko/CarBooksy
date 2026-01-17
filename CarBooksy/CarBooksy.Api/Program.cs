using CarBooksy.Api;
using CarBooksy.Api.Middlewares;
using CarBooksy.Application;
using CarBooksy.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddPersistanceServices()
    .AddApiServices(builder.Configuration);

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId("SWAGGER_CLIENT_ID");
        c.OAuthUsePkce();
    });
/*}*/

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();