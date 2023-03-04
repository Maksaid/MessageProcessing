using System.Security.Cryptography;
using System.Text;
using MessageProcessingService.DAL;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.DAL.Roles;
using MessageProcessingService.Dto;
using MessageProcessingService.Extentions;
using MessageProcessingService.Mapping;

namespace MessageProcessingService.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private DatabaseContext _context;

    public EmployeeService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(string name, Guid id, Guid departamentId,
        string login, string password, CancellationToken cancellationToken)
    {
        Department department = await _context.Departments.GetEntityAsync(departamentId, cancellationToken);
        var employeeAccount = new Account(Guid.NewGuid(), login, GetPasswordHash(password), id);
        var newEmployee = new Employee(id, name, department, employeeAccount);
        await _context.Accounts.AddAsync(employeeAccount, cancellationToken);
        await _context.Employees.AddAsync(newEmployee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newEmployee.AsDto();
    }

    private static string GetPasswordHash(string password)
    {
        using var hashingAlgorithm = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return BitConverter.ToString(hashingAlgorithm.ComputeHash(passwordBytes));
    }
}