using System.Text.Json.Serialization;

namespace Focu.Core.Common;

public abstract class Request
{
    [JsonIgnore]
    public Guid UserId { get; set; } = Guid.Empty;
}