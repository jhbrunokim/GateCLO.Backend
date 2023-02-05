using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using X.PagedList;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployees;

public class GetEmployeesResponse
{
    public IList<Domain.Entities.Employee> Employees { get; set; }
    //public string Name { get; set; }
    //public string Email { get; set; }
    //public string Tel { get; set; }
    //public DateTime Joined { get; set; }

    [IgnoreDataMember, JsonIgnore]
    public PagedListMetaData MetaData { get; set; }
}