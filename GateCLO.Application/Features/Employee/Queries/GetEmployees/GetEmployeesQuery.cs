using MediatR;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployees;

public record GetEmployeesQuery : IRequest<GetEmployeesResponse>
{
    public int page { get; set; }
    public int pageSize { get; set; }
}