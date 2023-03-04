using MessageProcessingService.DAL.Models;

namespace MessageProcessingService.DAL.Abstractions;

public abstract class Message
{
    public Message(Guid id, Department department, string senderType)
    {
        SenderType = senderType;
        Id = id;
        Department = department;
        State = "not processed";
    }

    public Message() { }
    public Guid Id { get; set; }
    public Department Department { get; set; }
    public string SenderType { get; set; }
    public string State { get; set; }
    public Guid? ProcessedBy { get; set; }
}