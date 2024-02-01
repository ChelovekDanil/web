using server.Services;
using server.Services.Interfaces;
using WebApi.DBClasses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddTransient<IFilmsService, FilmsService>();
builder.Services.AddTransient<ISerialsService, SerialsService>();
builder.Services.AddTransient<IPopularService, PopularService>();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapGet("/", () => "Hello World! ");

app.MapControllers();

app.Run();
