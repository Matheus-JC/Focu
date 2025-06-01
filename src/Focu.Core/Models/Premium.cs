namespace Focu.Core.Models;

public class Premium
{
    public Guid Id { get; set; }
    public DateTime StartedAt { get; set; } = DateTime.Now;
    public DateTime EndedAt { get; set; } = DateTime.Now;

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid UserId { get; set; }

    public bool IsActive
        => StartedAt <= DateTime.Now && EndedAt >= DateTime.Now;
}