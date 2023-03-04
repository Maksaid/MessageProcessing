using MessageProcessingService.DAL;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Extentions;
using MessageProcessingService.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingService.Services.Implementations;

public class ReportService : IReportService
{
    private DatabaseContext _context;
    private Department _department;
    private Employee _employee;

    public ReportService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ReportDto> CreateReport(Guid accountId, CancellationToken cancellationToken)
    {
        Account employeeAccount = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
        _employee = await _context.Employees.GetEntityAsync(employeeAccount.EmployeeId, cancellationToken);
        _department = await _context.Departments.GetEntityAsync(_employee.Department.Id, cancellationToken);
        Report report = new Report(
            Guid.NewGuid(),
            TotalDepartmentMessages(),
            TotalDepartmentProcessingMessages(),
            TotalDepartmentProcessedMessages(),
            await MessageTypeStatistics(),
            _employee.Id,
            _department.Id);
        return report.AsDto();
    }

    public string TotalDepartmentMessages()
    {
        return _context.Messages.Count(x => x.Department.Id == _department.Id).ToString();
    }

    public string TotalDepartmentProcessingMessages()
    {
        int size = _context.Messages.Count(x => (x.Department.Id == _department.Id) && x.State.Equals("processing"));
        return size.ToString();
    }

    public string TotalDepartmentProcessedMessages()
    {
        int size = _context.Messages.Count(x => (x.Department.Id == _department.Id) && x.State.Equals("processed"));
        return size.ToString();
    }

    public async Task<List<string>> MessageTypeStatistics()
    {
        var stats = new List<string>();
        var types = await _context.Messages.Select(x => x.SenderType).Distinct().ToListAsync();
        for (int i = 0; i < types.Count(); i++)
        {
            stats.Add(types[i] + " " + _context.Messages.Count(x => x.SenderType.Equals(types[i])));
        }

        return stats;
    }
}