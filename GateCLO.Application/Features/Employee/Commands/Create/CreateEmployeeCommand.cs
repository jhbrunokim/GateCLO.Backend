using MediatR;

namespace GateCLO.Application.Features.Employee.Commands.Create;


public record CreateEmployeeCommand : IRequest<IList<EmployeeVm>>
{
    public IList<EmployeeVm>? EmployeeVms { get; init; }
}