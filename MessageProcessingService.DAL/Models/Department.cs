using MessageProcessingService.DAL.Abstractions;

namespace MessageProcessingService.DAL.Models;

public class Department : IEquatable<Department>
{
    public Department(string name, Guid id)
    {
        DepartmentEmployees = new List<Employee>();
        Messages = new List<Message>();
        Name = name;
        Id = id;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<Employee> DepartmentEmployees { get; set; }
    /*
    public virtual List<Report> Reports { get; set; }
    */ 
    public virtual List<Message> Messages { get; set; }

    public bool Equals(Department? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Department)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}