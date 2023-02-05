using AutoMapper;
using GateCLO.Application.Features.Employee.Commands.Create;
using GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;
using GateCLO.Application.Features.Employee.Queries.GetEmployees;
using GateCLO.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeVm, Employee>().ReverseMap();

        CreateMap<Employee, CreateEmployeeResponse>();

        CreateMap<Employee, GetEmployeesVm>();

        CreateMap<Employee, GetEmployeeByNameVm>();
    }
}