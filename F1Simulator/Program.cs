using F1Simulator.TeamManagementService.Data;
using F1Simulator.TeamManagementService.Repositories;
using F1Simulator.TeamManagementService.Repositories.Interfaces;
using F1Simulator.TeamManagementService.Services;
using F1Simulator.TeamManagementService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<TeamRepository>();
builder.Services.AddSingleton<TeamManagementServiceConnection>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
