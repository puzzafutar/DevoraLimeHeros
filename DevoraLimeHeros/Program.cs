using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.Application.Factory;
using DevoraLimeHeros.Application.Manager;
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Application.Service;
using DevoraLimeHeros.Application.Service.Interface;
using DevorLimeHeros.Application.Providers;
using DevoraLimeHeros.Application.Provider.Interface;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;
using DevoraLimeHeros.Controllers;
using DevorLimeHeros.Middleware;

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

var seriLog = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("logs\\logfile.txt", rollingInterval: RollingInterval.Day) // Fájlba történõ naplózás beállítása
            .CreateLogger();

ILoggerFactory logger = LoggerFactory.Create(logging =>
{
    logging.AddSerilog(seriLog);

});
ILogger<RequestResponseLoggerMiddleware> requestResponseLogger = logger.CreateLogger<RequestResponseLoggerMiddleware>();
ILogger<HerosController> herosControllerLogger = logger.CreateLogger<HerosController>();
builder.Services.AddSingleton(requestResponseLogger);
builder.Services.AddSingleton(herosControllerLogger);

builder.Host.UseSerilog();

builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

builder.Host.UseSerilog();

builder.Services.AddSingleton(Log.Logger);

var app = builder.Build();

app.UseMiddleware<RequestResponseLoggerMiddleware>();

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
