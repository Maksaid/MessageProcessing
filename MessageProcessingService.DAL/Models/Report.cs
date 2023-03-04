using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingService.DAL.Models;

public class Report
{
    public Report(Guid id, string totalDepartmentMessages, string totalDepartmentProcessingMessages, string totalDepartmentProcessedMessages, List<string> messageTypeStatistics, Guid employeeId, Guid departmentId)
    {
        TotalDepartmentMessages = totalDepartmentMessages;
        TotalDepartmentProcessedMessages = totalDepartmentProcessedMessages;
        TotalDepartmentProcessingMessages = totalDepartmentProcessingMessages;
        MessageTypeStatistics = messageTypeStatistics;
        Id = id;
        EmployeeId = employeeId;
        DepartmentId = departmentId;
    }

    public string TotalDepartmentMessages { get; set; }
    public string TotalDepartmentProcessingMessages { get; set; }
    public string TotalDepartmentProcessedMessages { get; set; }
    public List<string> MessageTypeStatistics { get; set; }
    public Guid Id { get; set; }
    [ForeignKey("Employee")]
    public Guid EmployeeId { get; set; }
    [ForeignKey("Department")]
    public Guid DepartmentId { get; set; }
}