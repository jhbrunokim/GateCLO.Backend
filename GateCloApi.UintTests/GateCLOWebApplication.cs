using GateCLO.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GateCloApi.UintTests;

public class GateCLOWebApplication : WebApplicationFactory<Program>
{

    public GateCLOWebApplication()
    {
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(s =>
        {
            var descriptor = s.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<GateCloDbContext>));

            if (descriptor != null) s.Remove(descriptor);

            s.AddDbContext<GateCloDbContext>(o =>
            {
                o.UseInMemoryDatabase("GateCLODbForTesting");
            });
            
            var serviceProvider = s.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<GateCloDbContext>();
            appContext.Database.EnsureCreated();
        });

        return base.CreateHost(builder);
    }
}