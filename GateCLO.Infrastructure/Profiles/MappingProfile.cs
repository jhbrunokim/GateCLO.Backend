using AutoMapper;
using GateCLO.Application.Features.Employee.Commands.Create;
using GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;
using GateCLO.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, GetEmployeeByNameResponse>();

        CreateMap<EmployeeVm, Employee>().ReverseMap();

        CreateMap<Employee, CreateEmployeeResponse>();
    }
}