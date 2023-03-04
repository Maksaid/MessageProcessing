using MessageProcessingService.DAL.Models;
using MessageProcessingService.DAL.Roles;

namespace MessageProcessingService.Dto;

public record EmployeeDto(string Name, Guid Id, Guid DepartmentId, Guid AccountId);