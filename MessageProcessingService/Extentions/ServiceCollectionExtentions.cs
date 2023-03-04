using MessageProcessingService.DAL.Models;
using MessageProcessingService.Services;
using MessageProcessingService.Services.Implementations;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace MessageProcessingService.Extentions;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IMessageService, MessageService>();
        collection.AddScoped<IDepartmentService, DepartmentService>();
        collection.AddScoped<IReportService, ReportService>();
        collection.AddScoped<IAccountService, AccountService>();
        return collection;
    }
}