using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployees;

public class GetEmployeesResponse
{
    public ActionResult<IList<GetEmployeesVm>>? Employees { get; init; }

    [IgnoreDataMember, JsonIgnore]
    public PagedListMetaData? MetaData { get; init; }
}