using System.Text.Json;
using GateCLO.Application.Contracts.Infrastructure;
using GateCLO.Application.Features.Employee.Commands.Create;
using GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;
using GateCLO.Application.Features.Employee.Queries.GetEmployees;
using Microsoft.AspNetCore.Mvc;

namespace GateCLO.Api.Controllers;

/// <summary>
/// ����
/// </summary>
public class EmployeeController : ApiControllerBase
{
    private readonly ICsvFileParser _csvFileParser;

    /// <summary>
    /// Employee Controller
    /// </summary>
    /// <param name="csvFileParser">DI Csv file Parser Service</param>
    public EmployeeController(ICsvFileParser csvFileParser)
    {
        _csvFileParser = csvFileParser;
    }

    /// <summary>
    /// �������� �⺻ ���� ������ ���� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="query"></param>
    /// <returns>���� ���� ����</returns>
    [HttpGet]
    public async Task<ActionResult<IList<GetEmployeesVm>>?> GetEmployeeList([FromQuery] GetEmployeesQuery query)
    {
        var res = await Mediator.Send(query);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(res.MetaData));

        return res.Employees;
    }

    /// <summary>
    /// ������ �⺻ ���� ������ ���� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="Name">���� �̸�</param>
    /// <returns>������ �� ��������</returns>
    [HttpGet("{Name}")]
    public async Task<ActionResult<IList<GetEmployeeByNameVm>>?> GetEmployeeByName(string Name)
    {
        var res = await Mediator.Send(new GetEmployeeByNameQuery { Name = Name });

        return res.Employees;
    }

    /// <summary>
    /// ������ �⺻ ���� ������ �߰� �� �� �ֽ��ϴ�.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Consumes("application/json")]
    public async Task<ActionResult<IList<EmployeeVm>>> CreateEmployee([FromBody] IList<EmployeeVm> command)
    {
        return Created(nameof(CreateEmployee), await Mediator.Send(new CreateEmployeeCommand { EmployeeVms = command }));
    }

    /// <summary>
    /// ������ �⺻ ���� ������ �߰� �� �� �ֽ��ϴ�.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<CreateEmployeeResponse>> CreateEmployee([FromForm] IFormFile formFile)
    {
        switch (formFile.ContentType)
        {
            case "application/json":
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var command = await JsonSerializer.DeserializeAsync<IList<EmployeeVm>>(formFile.OpenReadStream(), options);
                if (command != null)
                {
                    return Created(nameof(CreateEmployee), await Mediator.Send(new CreateEmployeeCommand { EmployeeVms = command }));
                }
                break;
            case "text/csv":
                var commandCsv = await _csvFileParser.EmployeeCsvReader(formFile);

                return Created(nameof(CreateEmployee), await Mediator.Send(new CreateEmployeeCommand { EmployeeVms = commandCsv }));
            default:
                return new UnsupportedMediaTypeResult();
        }

        return BadRequest();
    }
}