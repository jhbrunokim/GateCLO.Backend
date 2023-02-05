using Microsoft.AspNetCore.Mvc;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;

public class GetEmployeeByNameResponse
{
    public ActionResult<IList<GetEmployeeByNameVm>>? Employees { get; init; }
}