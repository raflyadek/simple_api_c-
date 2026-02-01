using Application;
using Application.Interface;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//dependency injection
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")
    ).UseSnakeCaseNamingConvention()
);
//inject service and repo with scope lifetime/per request
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
Console.WriteLine("success connect to db");


var app = builder.Build();
app.MapControllers();
//run app
app.Run();