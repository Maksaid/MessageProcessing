using MessageProcessingService.DAL.Models;

namespace MessageProcessingService.DAL.Roles;

public class Role
{
    public Role(EmployeeRole role)
    {
        EmployeeRole = role.ToString();
    }
    public string EmployeeRole { get; set; }
}
public enum EmployeeRole
{
    Employee = 0,
    Manager = 1,
    Admin = 2
}