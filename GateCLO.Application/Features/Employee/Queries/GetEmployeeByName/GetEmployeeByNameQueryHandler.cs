using AutoMapper;
using GateCLO.Application.Contracts.Infrastructure;
using MediatR;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;

public class GetEmployeeByNameHandler : IRequestHandler<GetEmployeeByNameQuery, GetEmployeeByNameResponse>
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public GetEmployeeByNameHandler(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetEmployeeByNameResponse> Handle(GetEmployeeByNameQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetEmployeeByName(request.Name);
        
        return _mapper.Map<GetEmployeeByNameResponse>(entity);
    }
}