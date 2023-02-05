using MediatR;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;

public record GetEmployeeByNameQuery : IRequest<GetEmployeeByNameResponse>
{
    public string? Name { get; init; }
}