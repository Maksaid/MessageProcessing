using System.Security.Claims;
using MessageProcessingService.Dto;
using MessageProcessingService.Presentation.Constants;
using MessageProcessingService.Services;
using MessageProcessingService.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = PolicyName.ManagerPolicy)]
public class ReportController : ControllerBase
{
    private IReportService _reportService;

    public ReportController(IReportService service)
    {
        _reportService = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("create-report")]
    public async Task<ActionResult<ReportDto>> CreateReport()
    {
        Claim? empIdClaim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        string? stringEmpId = empIdClaim?.Value;
        Guid id;
        if (empIdClaim is not null && stringEmpId is not null)
        {
            id = Guid.Parse(stringEmpId);
            ReportDto dto = await _reportService.CreateReport(id, CancellationToken);
            return Ok(dto);
        }

        throw new ArgumentNullException("some login exception accured, id of employee is null somehow");
    }
}