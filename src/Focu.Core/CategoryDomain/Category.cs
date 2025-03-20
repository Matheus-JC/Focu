using Focu.Core.Common;

namespace Focu.Core.CategoryDomain;

public class Category : Entity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
}