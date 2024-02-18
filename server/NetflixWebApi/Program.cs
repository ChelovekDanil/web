using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Netflix.Application.Service;
using Netflix.Domain.common;
using Netflix.Domain.Interface;
using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Interface.Services;
using Netflix.Infrastucture.PopularMovieService;
using Netflix.Infrastucture.Repositories;
using NetflixWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddDbContext<WebContext>(opt =>
    opt.UseNpgsql());

builder.Services.AddKeyedScoped<IMovieService, PopularMovieService>("popularmovie");
builder.Services.AddKeyedScoped<IMovieService, FilmService>("film");
builder.Services.AddKeyedScoped<IMovieService, SerialService>("serial");
builder.Services.AddScoped<IJwtService, JwtTokenService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAuthTokensService, AuthTokensService>();

builder.Services.AddScoped<IPopularMovieRepository, PopularMovieRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ISerialsRepository, SerialsRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAuthTokensRepository, AuthTokensRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials().AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();