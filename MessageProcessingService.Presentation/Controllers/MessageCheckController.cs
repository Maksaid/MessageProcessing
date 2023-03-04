using System.Security.Claims;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Presentation.Constants;
using MessageProcessingService.Presentation.Models.Employees;
using MessageProcessingService.Presentation.Models.Messages;
using MessageProcessingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = PolicyName.EmployeePolicy)]
public class MessageCheckController : ControllerBase
{
    private IMessageService _messageService;

    public MessageCheckController(IMessageService service)
    {
        _messageService = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("set-processing-state")]
    public async Task<ActionResult<MessageStateChangedDto>> SetProcessingStateAsync(Guid messageId)
    {
        Claim? empIdClaim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        string? stringEmpId = empIdClaim?.Value;
        Guid id;
        if (empIdClaim is not null && stringEmpId is not null)
        {
            id = Guid.Parse(stringEmpId);
            MessageStateChangedDto dto = await _messageService.SetProcessingState(messageId, CancellationToken, id);
            return Ok(dto);
        }

        throw new ArgumentNullException("some login exception accured, id of employee is null somehow");
    }

    [HttpPost("set-processed-state")]
    public async Task<ActionResult<MessageStateChangedDto>> SetProcessedStateAsync(Guid messageId)
    {
        Claim? empIdClaim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        string? stringEmpId = empIdClaim?.Value;
        Guid id;
        if (empIdClaim is not null && stringEmpId is not null)
        {
            id = Guid.Parse(stringEmpId);
            MessageStateChangedDto dto = await _messageService.SetMessageProcessed(messageId, CancellationToken, id);
            return Ok(dto);
        }

        throw new ArgumentNullException("some login exception accured, id of employee is null somehow");
    }
}