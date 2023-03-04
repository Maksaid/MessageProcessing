using MessageProcessingService.DAL.Abstractions;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Mapping;

public static class MessageChangedStateMapping
{
    public static MessageStateChangedDto AsDto(this Message message, Guid employeeId) =>
        new MessageStateChangedDto(message.Id, message.State, employeeId);

}