using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Mapping;

public static class ReportMapping
{
    public static ReportDto AsDto(this Report report) =>
        new ReportDto(report.TotalDepartmentMessages, report.TotalDepartmentProcessingMessages, report.TotalDepartmentProcessedMessages, report.MessageTypeStatistics, report.Id, report.EmployeeId, report.DepartmentId);
}