using System.Text.Json.Serialization;

namespace Focu.Core.Requests;

public abstract class Request
{
    [JsonIgnore]
    public Guid UserId { get; set; } = Guid.Empty;
}