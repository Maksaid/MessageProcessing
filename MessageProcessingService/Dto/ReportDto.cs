namespace MessageProcessingService.Dto;

public record ReportDto(string TotalDepartmentMessages, string TotalDepartmentProcessingMessages, string TotalDepartmentProcessedMessages, List<string> MessageTypeStatistics, Guid reportId, Guid reportEmployeeId, Guid reportDepartmentId);