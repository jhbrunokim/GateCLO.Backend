using AutoMapper;
using GateCLO.Application.Contracts.Infrastructure;
using MediatR;
using X.PagedList;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployees;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeesQuery, IPagedList<Domain.Entities.Employee>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IPagedList<Domain.Entities.Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        if (request.page == 0)
        {
            return await _repository.GetAllAsync();
        }

        return await _repository.GetEmployeeList(request.page, request.pageSize);
    }
}