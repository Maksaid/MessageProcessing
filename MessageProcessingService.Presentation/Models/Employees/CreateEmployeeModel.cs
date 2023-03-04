using MessageProcessingService.DAL.Abstractions;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.DAL.Roles;

namespace MessageProcessingService.Presentation.Models.Employees;

public record CreateEmployeeModel(string Name, Guid DepartmentId, string Login, string Password);