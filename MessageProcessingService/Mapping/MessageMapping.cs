using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Mapping;

public static class MessageMapping
{
    public static EmailTextMessageDto AsDto(this EmailTextMessage textMessage) =>
        new EmailTextMessageDto(textMessage.Text, textMessage.Department.Id, textMessage.EmailAddress, textMessage.Id,
            textMessage.SenderType);
}