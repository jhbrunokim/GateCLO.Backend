using GateCLO.Application.Contracts.Infrastructure;
using GateCLO.Domain.Entities;
using X.PagedList;

namespace GateCLO.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly GateCloDbContext _context;

    public EmployeeRepository(GateCloDbContext context)
    {
        _context = context;
    }

    public Task<IPagedList<Employee>> GetAllAsync()
    {
        return Task.FromResult(_context.Employees.ToPagedList());
    }

    public async Task<IList<Employee>> GetEmployeeByName(string name)
    {
        return await _context.Employees.Where(s => s.Name == name).ToListAsync();
    }

    public async Task<IPagedList<Employee>> GetEmployeeList(int page, int pageSize)
    {
        return await _context.Employees.ToPagedListAsync(page, pageSize);
    }

    public async Task<IList<Employee>> AddEmployeeAsync(IList<Employee> entities)
    {
        var id = _context.Employees.Count();

        for (var i = 1; i <= entities.Count; i++)
        {
            entities[i - 1].Id = id + i;
        }

        await _context.Employees.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

        return entities;
    }
}