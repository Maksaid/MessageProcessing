using MessageProcessingService.DAL.Models;
using MessageProcessingService.DAL.Roles;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> CreateEmployeeAsync(string name, Guid id, Guid departamentId,
        string login, string password,
        CancellationToken cancellationToken);
}