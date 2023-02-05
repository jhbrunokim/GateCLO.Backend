using MediatR;
using X.PagedList;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployees;

public record GetEmployeesQuery : IRequest<IPagedList<Domain.Entities.Employee>>
{
    public int page { get; set; }
    public int pageSize { get; set; }
}