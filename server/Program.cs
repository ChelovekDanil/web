using server.Services;
using server.Services.Interfaces;
using WebApi.DBClasses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddKeyedTransient<IMovieService, FilmsService>("films");
builder.Services.AddKeyedTransient<IMovieService, SerialsService>("serials");
builder.Services.AddKeyedTransient<IMovieService, PopularService>("popular");

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapGet("/", () => "Hello World! ");

app.MapControllers();

app.Run();
