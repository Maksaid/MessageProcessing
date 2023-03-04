using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Presentation.Constants;
using MessageProcessingService.Presentation.Models.Departament;
using MessageProcessingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingService.Presentation.Controllers;

[ApiController]
[Authorize(Policy = PolicyName.AdminPolicy)]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private IDepartmentService _departmentService;
    public DepartmentController(IDepartmentService service)
    {
        _departmentService = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("Create-new-department")]
    public async Task<ActionResult<DepartmentDto>> CreateAsync([FromBody] CreateDepartmentModel model)
    {
        var departament = await _departmentService.CreateDepartmentAsync(model.Name, CancellationToken);
        return Ok(departament);
    }

    [HttpPost("Delete-department")]
    public Task DeleteAsync(Guid departmentId)
    {
         return _departmentService.DeleteDepartmentAsync(departmentId, CancellationToken);
    }
}