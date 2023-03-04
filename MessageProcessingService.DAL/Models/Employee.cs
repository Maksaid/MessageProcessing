using MessageProcessingService.DAL.Roles;

namespace MessageProcessingService.DAL.Models;

public class Employee
{
    public Employee(Guid id, string name, Department department, Account account)
    {
        Department = department;
        Id = id;
        Name = name;
        Account = account;
    }

    public Employee()
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual Department Department { get; set; }
    public virtual Account Account { get; set; }
}