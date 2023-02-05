using GateCLO.Domain.Entities;
using X.PagedList;

namespace GateCLO.Application.Contracts.Infrastructure;

public interface IEmployeeRepository
{
    public Task<IPagedList<Employee>> GetAllAsync();
    public Task<Employee> GetEmployeeByName(string name);
    public Task<IPagedList<Employee>> GetEmployeeList(int page, int pageSize);
    public Task<IList<Employee>> AddEmployeeAsync(IList<Employee> entity);
}