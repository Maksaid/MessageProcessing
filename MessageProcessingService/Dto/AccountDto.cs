namespace MessageProcessingService.Dto;

public record AccountDto(Guid AccountId, Guid EmployeeId, string Login, string Role);