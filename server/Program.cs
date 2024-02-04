using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Models;
using server.Services;
using server.Services.Interfaces;
using WebApi.DBClasses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddKeyedTransient<IMovieService, FilmsService>("films");
builder.Services.AddKeyedTransient<IMovieService, SerialsService>("serials");
builder.Services.AddKeyedTransient<IMovieService, PopularService>("popular");
builder.Services.AddKeyedTransient<IJwtToken, JwtTokenService>("jwtToken");

builder.Services.AddDbContext<WebContext>(opt => 
    opt.UseNpgsql());

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

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();