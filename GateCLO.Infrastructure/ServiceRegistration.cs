using GateCLO.Application.Contracts.Infrastructure;
using GateCLO.Infrastructure;
using GateCLO.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GateCLO.Infrastructure.Files;

namespace GateClo.Infrastructure;

public static class ServiceRegiatration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddDbContext<GateCloDbContext>(o =>
        {
            o.UseInMemoryDatabase("GateCLODb");
        });

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ICsvFileParser, CsvFileParser>();

        services.AddScoped<GateCloDbContextInitializer>();

        return services;
    }
}