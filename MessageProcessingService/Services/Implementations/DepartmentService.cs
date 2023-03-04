using MessageProcessingService.DAL;
using MessageProcessingService.DAL.Models;
using MessageProcessingService.Dto;
using MessageProcessingService.Extentions;
using MessageProcessingService.Mapping;

namespace MessageProcessingService.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private DatabaseContext _context;

    public DepartmentService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<DepartmentDto> CreateDepartmentAsync(string name, CancellationToken cancellationToken)
    {
        var department = new Department(name, Guid.NewGuid());
        _context.Departments.Add(department);
        await _context.SaveChangesAsync(cancellationToken);

        return department.AsDto();
    }

    public async Task DeleteDepartmentAsync(Guid id, CancellationToken cancellationToken)
    {
        var department = await _context.Departments.GetEntityAsync(id, cancellationToken);
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync(cancellationToken);
    }
}