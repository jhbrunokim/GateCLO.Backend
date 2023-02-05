using AutoMapper;
using GateCLO.Application.Contracts.Infrastructure;
using MediatR;

namespace GateCLO.Application.Features.Employee.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IList<EmployeeVm>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<EmployeeVm>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.AddEmployeeAsync(_mapper.Map<IList<Domain.Entities.Employee>>(request.EmployeeVms));

        return _mapper.Map<IList<EmployeeVm>>(entity);
    }
}