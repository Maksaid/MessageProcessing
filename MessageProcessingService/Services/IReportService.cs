using MessageProcessingService.Dto;

namespace MessageProcessingService.Services;

public interface IReportService
{
    Task<ReportDto> CreateReport(Guid employeeId, CancellationToken cancellationToken);
    string TotalDepartmentMessages();
    string TotalDepartmentProcessingMessages();
    string TotalDepartmentProcessedMessages();
    Task<List<string>> MessageTypeStatistics();
}