using MessageProcessingService.DAL.Models;

namespace MessageProcessingService.Presentation.Models.Messages;

public record CreateEmailTextMessageModel(string MessageText, Guid DepartamentId, string SenderEmail);
