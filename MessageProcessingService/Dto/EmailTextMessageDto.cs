namespace MessageProcessingService.Dto;

public record EmailTextMessageDto(string text, Guid departmentId, string emailAddress, Guid id, string type);
