using Microsoft.AspNetCore.Http;

namespace GateCLO.Application.Contracts.Infrastructure;

public interface ICsvFileParser
{
    public Task<List<EmployeeVm>> EmployeeCsvReader(IFormFile file);
}