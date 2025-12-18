using F1Simulator.CompetitionService.Data;
using F1Simulator.CompetitionService.Repositories;
using F1Simulator.CompetitionService.Repositories.Interfaces;
using F1Simulator.CompetitionService.Services;
using F1Simulator.CompetitionService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<CompetitionServiceConnection>();
builder.Services.AddScoped< ICircuitRepository, CircuitRepository>();
builder.Services.AddScoped< ICircuitService, CircuitService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
