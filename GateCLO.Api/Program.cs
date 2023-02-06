using GateCLO.Application;
using Microsoft.OpenApi.Models;
using System.Reflection;
using GateClo.Infrastructure;
using GateCLO.Infrastructure;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.ResolveConflictingActions(i => i.FirstOrDefault());
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GateCLO.Api",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "BrunoKim",
            Email = "bobhappy2000@gmail.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    s.IncludeXmlComments(xmlPath);
});

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console(Serilog.Events.LogEventLevel.Error)
    .WriteTo.File(@"log.txt", Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<GateCloDbContextInitializer>();
        await initialiser.InitializeAsync();
    }
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
