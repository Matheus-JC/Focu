using Focu.Core.CategoryDomain;
using Focu.Core.Common;

namespace Focu.Core.TransactionDomain;

public class Transaction : Entity
{
    public required string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidOrReceivedAt { get; set; }
    public TransactionType Type { get; set; }
    public required decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public Guid UserId { get; set; }
}