using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MessageProcessingService.DAL.Models;

public class Account
{
    public Account(Guid id, string login, string password, Guid employeeId)
    {
        Login = login;
        Password = password;
        Id = id;
        EmployeeId = employeeId;
    }

    public string Login { get; set; }
    public string Password { get; set; }
    public Guid Id { get; set; }
    [ForeignKey("Employee")]
    public Guid EmployeeId { get; set; }
    public bool AllowCreateReports { get; set; }
    public bool AllowCheckMessages { get; set; }
    public bool AllowChangeSystem { get; set; }
}