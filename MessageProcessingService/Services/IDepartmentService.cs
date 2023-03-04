using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;

namespace MessageProcessingService.Services;

public interface IDepartmentService
{
    public Task<DepartmentDto> CreateDepartmentAsync(string name, CancellationToken cancellationToken);
    public Task DeleteDepartmentAsync(Guid id, CancellationToken cancellationToken);

}