using System.Security.Claims;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.DAL.Roles;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Services;

public interface IMessageService
{
    Task<EmailTextMessageDto> CreateEmailTextMessageAsync(string modelMessageText, Guid departmentId, string emailAddress, string senderType, CancellationToken cancellationToken);

    Task<MessageStateChangedDto> SetProcessingState(Guid messageId, CancellationToken cancellationToken, Guid employeeAccountId);

    Task<MessageStateChangedDto> SetMessageProcessed(Guid messageId, CancellationToken cancellationToken, Guid employeeAccountId);
}