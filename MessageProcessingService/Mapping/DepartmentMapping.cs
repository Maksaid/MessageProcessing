using System.Runtime.Serialization;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Mapping;

public static class DepartmentMapping
{
    public static DepartmentDto AsDto(this Department department) =>
        new DepartmentDto(department.Name, department.Id);
}