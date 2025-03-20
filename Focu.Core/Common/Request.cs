namespace Focu.Core.Common;

public abstract class Request
{
    public Guid UserId { get; set; } = Guid.Empty;
}