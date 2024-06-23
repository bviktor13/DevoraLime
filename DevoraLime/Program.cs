using FluentValidation.AspNetCore;
using HeroBattle.API.Mapping;
using HeroBattle.API.Requests;
using HeroBattle.Application.Repositories;
using HeroBattle.Infrastructure.Context;
using HeroBattle.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Read the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the DbContext with the connection string
builder.Services.AddDbContext<HeroBattleDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IArenaRepository, ArenaRepository>();
builder.Services.AddScoped<IBattleRepository, BattleRepository>();

builder.Services.RegisterMapsterConfiguration();

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateArenaRequest>();
        fv.RegisterValidatorsFromAssemblyContaining<GetArenaHistoryRequest>();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
