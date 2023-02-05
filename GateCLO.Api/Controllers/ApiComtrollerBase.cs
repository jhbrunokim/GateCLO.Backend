using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GateCLO.Api.Controllers;

/// <summary>
/// API Controller Base
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    /// <summary>
    /// Mediator
    /// </summary>
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}