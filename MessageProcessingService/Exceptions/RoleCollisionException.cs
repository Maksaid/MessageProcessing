namespace MessageProcessingService.Exceptions;

public class RoleCollisionException : Exception
{
    public RoleCollisionException(Guid id)
        : base($"person's role with accountId {id} can't be employee and manager at the same time, please remove rights first")
    {
    }
}