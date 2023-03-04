using MessageProcessingService.DAL.Abstractions;

namespace MessageProcessingService.DAL.Models;

public class EmailTextMessage : Message
{
    public EmailTextMessage(string text, Department department, string emailAddress, Guid id, string type)
        : base(id, department, type)
    {
        Text = text;
        EmailAddress = emailAddress;
    }

    public EmailTextMessage()
    {
    }

    public string Text { get; set; }
    public string EmailAddress { get; set; }
}