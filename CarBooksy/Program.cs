using CarBooksy.Application.Modules.Cars.Commands;
using CarBooksy.Application.Modules.Cars.Queries;
using CarBooksy.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetCarByIdHandler).Assembly);
});

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.Scan(scan => scan
    .FromAssemblies(typeof(ICreateCarDbProvider).Assembly)
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DbProvider")))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);


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

app.UseMiddleware<CarBooksy.Api.Middlewares.ExceptionHandlerMiddleware>();

app.Run();