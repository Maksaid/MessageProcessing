namespace MessageProcessingService.Exceptions;

public class DifferentDepartmentException : Exception
{
    public DifferentDepartmentException(Guid emplId, Guid emplDepID, Guid messId, Guid messDepId)
        : base(
            $"Employee with id: {emplId} has depID {emplDepID}, but message {messId} has different dep {messDepId}. Employee must be from the same department to work on message")
    {
    }
}