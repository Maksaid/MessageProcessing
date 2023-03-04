using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Presentation.Constants;
using MessageProcessingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingService.Presentation.Controllers;

[ApiController]
[Authorize(Policy = PolicyName.AdminPolicy)]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("make-employee-admin")]
    public async Task<ActionResult<AccountDto>> MakeAdmin(Guid accId)
    {
        AccountDto acc = await _service.GiveAdminRights(accId, CancellationToken);
        return Ok(acc);
    }

    [HttpPost("make-employee-employee")]
    public async Task<ActionResult<AccountDto>> MakeEmployee(Guid accId)
    {
        AccountDto acc = await _service.GiveEmployeeRights(accId, CancellationToken);
        return Ok(acc);
    }

    [HttpPost("make-employee-manager")]
    public async Task<ActionResult<AccountDto>> MakeManager(Guid accId)
    {
        AccountDto acc = await _service.GiveManagerRights(accId, CancellationToken);
        return Ok(acc);
    }
}