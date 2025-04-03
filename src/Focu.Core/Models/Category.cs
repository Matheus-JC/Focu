using Focu.Core.Common;

namespace Focu.Core.Models;

public class Category : Model
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
}