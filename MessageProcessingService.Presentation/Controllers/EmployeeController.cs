using MessageProcessingService.Dto;
using MessageProcessingService.Presentation.Constants;
using MessageProcessingService.Presentation.Models.Employees;
using MessageProcessingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingService.Presentation.Controllers;

[ApiController]
[Authorize(Policy = PolicyName.AdminPolicy)]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService service)
    {
        _employeeService = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("create-employee")]
    public async Task<ActionResult<EmployeeDto>> CreateAsync([FromBody] CreateEmployeeModel model)
    {
        var employee = await _employeeService.CreateEmployeeAsync(model.Name, Guid.NewGuid(), model.DepartmentId, model.Login, model.Password, CancellationToken);
        return Ok(employee);
    }
}