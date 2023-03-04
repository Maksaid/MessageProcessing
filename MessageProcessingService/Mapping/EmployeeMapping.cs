using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Mapping;

public static class EmployeeMapping
{
    public static EmployeeDto AsDto(this Employee employee) =>
        new EmployeeDto(employee.Name, employee.Id, employee.Department.Id, employee.Account.Id);
}