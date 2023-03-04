namespace MessageProcessingService.Dto;

public record MessageStateChangedDto(Guid messageId, string currentMessageState, Guid? employeeId);
