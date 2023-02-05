using GateCLO.Domain.Entities;

namespace GateCLO.Infrastructure;

public class GateCloDbContextInitializer
{
    private readonly GateCloDbContext _context;

    public GateCloDbContextInitializer(GateCloDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        if (!_context.Employees.Any())
        {
            var employees = new[]
            {
                new Employee
                {
                    Id = 1, Name = "±èÃ¶¼ö", Email = "charles@clovf.com", Tel = "01075312468",
                    Joined = new DateTime(2018, 03, 07)
                },
                new Employee
                {
                    Id = 2, Name = "¹Ú¿µÈñ", Email = "matilda@clovf.com", Tel = "01087654321",
                    Joined = new DateTime(2021, 04, 28)
                },
                new Employee
                {
                    Id = 3, Name = "È«±æµ¿", Email = "kildong.hong@clovf.com", Tel = "01012345678",
                    Joined = new DateTime(2015, 08, 15)
                }
            };

            _context.Employees.AddRange(employees);
            await _context.SaveChangesAsync();
        }
    }
}