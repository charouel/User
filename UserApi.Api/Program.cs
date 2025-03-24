using UserApi.Application.Services;
using UserApi.Domain.Interface;
using UserApi.Infrastrecture.Data;
using UserApi.Infrastrecture.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using FluentValidation.AspNetCore;
using FluentValidation;
using UserApi.Application.Validators;
using MediatR;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Configuration de Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // Lire depuis appsettings.json
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog(); // Utiliser Serilog au lieu du logger par défaut

// Add services to the container.
// Initialisation de SQLite
Batteries.Init();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidator>(); // Scanne tous les validateurs

builder.Services.AddMediatR(typeof(UserApi.Application.Features.User.Commands.CreateUserCommand).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.Run();
