using AutoMapper;
using GateCLO.Application.Contracts.Infrastructure;
using MediatR;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployees;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResponse>
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        if (request.page == 0)
        {
            var temp = await _repository.GetAllAsync();
            return new GetEmployeesResponse
            {
                Employees = _mapper.Map<List<GetEmployeesVm>>(temp.ToList()),
                MetaData = temp.GetMetaData()
            };
        }

        var templ = await _repository.GetEmployeeList(request.page, request.pageSize);

        return new GetEmployeesResponse
        {
            Employees = _mapper.Map<List<GetEmployeesVm>>(templ.ToList()),
            MetaData = templ.GetMetaData()
        };
    }
}