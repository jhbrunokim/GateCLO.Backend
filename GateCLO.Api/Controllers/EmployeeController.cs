using System.Text.Json;
using GateCLO.Application.Contracts.Infrastructure;
using GateCLO.Application.Features.Employee.Commands.Create;
using GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;
using GateCLO.Application.Features.Employee.Queries.GetEmployees;
using GateCLO.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GateCLO.Api.Controllers;

/// <summary>
/// 직원
/// </summary>
public class EmployeeController : ApiControllerBase
{
    private readonly ICsvFileParser _csvFileParser;

    public EmployeeController(ICsvFileParser csvFileParser)
    {
        _csvFileParser = csvFileParser;
    }

    /// <summary>
    /// 직원들의 기본 연락 정보를 얻을 수 있습니다.
    /// </summary>
    /// <param name="query"></param>
    /// <returns>직원 연락 정보</returns>
    [HttpGet]
    public async Task<ActionResult<IList<Employee>>> GetEmployeeList([FromQuery] GetEmployeesQuery query)
    {
        var res = await Mediator.Send(query);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(res.GetMetaData()));

        return await res.ToListAsync();
    }

    /// <summary>
    /// 직원의 기본 연락 정보를 얻을 수 있습니다.
    /// </summary>
    /// <param name="Name">직원 이름</param>
    /// <returns>직원의 상세 연락정보</returns>
    [HttpGet("{Name}")]
    public async Task<ActionResult<GetEmployeeByNameResponse>> GetEmployeeByName(string Name)
    {
        return await Mediator.Send(new GetEmployeeByNameQuery { Name = Name });
    }

    /// <summary>
    /// 직원의 기본 연락 정보를 추가 할 수 있습니다.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Consumes("application/json")]
    public async Task<ActionResult<IList<EmployeeVm>>> CreateEmployee([FromBody] IList<EmployeeVm> command)
    {
        return Created(nameof(CreateEmployee), await Mediator.Send(new CreateEmployeeCommand { EmployeeVms = command }));
    }

    /// <summary>
    /// 직원의 기본 연락 정보를 추가 할 수 있습니다.
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
                var commandcsv = await _csvFileParser.EmployeeCsvReader(formFile);

                return Created(nameof(CreateEmployee), await Mediator.Send(new CreateEmployeeCommand { EmployeeVms = commandcsv }));
                break;
            default:
                return new UnsupportedMediaTypeResult();
        }

        return BadRequest();
    }
}