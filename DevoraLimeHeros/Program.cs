using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.Application.Factory;
using DevoraLimeHeros.Application.Manager;
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Application.Service;
using DevoraLimeHeros.Application.Service.Interface;
using DevorLimeHeros.Application.Providers;
using DevoraLimeHeros.Application.Provider.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IArenaManager, ArenaManager>();
builder.Services.AddSingleton<IHeroFactory, HeroFactory>();
builder.Services.AddSingleton<IArenaService, ArenaService>();
builder.Services.AddSingleton<IHeroService, HeroService>();
builder.Services.AddSingleton<IRandomProvider, RandomProvider>();

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

app.Run();
