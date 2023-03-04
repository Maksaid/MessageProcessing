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
public class MessageController : ControllerBase
{
    private IMessageService _messageService;

    public MessageController(IMessageService service)
    {
        _messageService = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("create-message")]
    public async Task<ActionResult<EmailTextMessageDto>> CreateAsync([FromBody] CreateEmailTextMessageModel model)
    {
        var message = await _messageService.CreateEmailTextMessageAsync(model.MessageText, model.DepartamentId, model.SenderEmail,  "email", CancellationToken);
        return Ok(message);
    }
}