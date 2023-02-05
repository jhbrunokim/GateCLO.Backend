using GateCLO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GateCLO.Infrastructure;

public class GateCloDbContext : DbContext
{
    public GateCloDbContext()
    {

    }

    public GateCloDbContext(DbContextOptions<GateCloDbContext> options) : base(options)
    {

    }

    public DbSet<Employee> Employees => Set<Employee>();
}