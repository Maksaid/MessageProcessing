using MessageProcessingService.DAL;
using MessageProcessingService.DAL.Abstractions;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Exceptions;
using MessageProcessingService.Extentions;
using MessageProcessingService.Mapping;


namespace MessageProcessingService.Services.Implementations;

public class MessageService : IMessageService
{
    private DatabaseContext _context;

    public MessageService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<EmailTextMessageDto> CreateEmailTextMessageAsync(
        string modelMessageText,
        Guid departmentId,
        string emailAddress,
        string senderType,
        CancellationToken cancellationToken)
    {
        var department = await _context.Departments.GetEntityAsync(departmentId, cancellationToken);
        var message = new EmailTextMessage(modelMessageText, department, emailAddress, Guid.NewGuid(), senderType);

        _context.Messages.Add(message);
        await _context.SaveChangesAsync(cancellationToken);
        return message.AsDto();
    }

    public async Task<MessageStateChangedDto> SetProcessingState(Guid messageId, CancellationToken cancellationToken, Guid employeeAccountId)
    {
        Account employeeAccount = await _context.Accounts.GetEntityAsync(employeeAccountId, cancellationToken);
        Employee employee = await _context.Employees.GetEntityAsync(employeeAccount.EmployeeId, cancellationToken);
        Message messageToCheck = await _context.Messages.GetEntityAsync(messageId, cancellationToken);
        if (!employee.Department.Id.Equals(messageToCheck.Department.Id))
        {
            throw new DifferentDepartmentException(employeeAccountId, employee.Department.Id, messageId, messageToCheck.Department.Id);
        }

        messageToCheck.State = "processing";
        await _context.SaveChangesAsync(cancellationToken);
        return messageToCheck.AsDto(employee.Id);
    }

    public async Task<MessageStateChangedDto> SetMessageProcessed(Guid messageId, CancellationToken cancellationToken, Guid employeeAccountId)
    {
        Account employeeAccount = await _context.Accounts.GetEntityAsync(employeeAccountId, cancellationToken);
        Employee employee = await _context.Employees.GetEntityAsync(employeeAccount.EmployeeId, cancellationToken);
        Message messageToCheck = await _context.Messages.GetEntityAsync(messageId, cancellationToken);
        if (!employee.Department.Id.Equals(messageToCheck.Department.Id))
        {
            throw new DifferentDepartmentException(employeeAccountId, employee.Department.Id, messageId, messageToCheck.Department.Id);
        }

        messageToCheck.State = "processed";
        messageToCheck.ProcessedBy = employee.Id;
        await _context.SaveChangesAsync(cancellationToken);
        return messageToCheck.AsDto(employee.Id);
    }
}