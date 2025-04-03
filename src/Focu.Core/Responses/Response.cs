using System.Net;
using System.Text.Json.Serialization;
using Focu.Core.Common;

namespace Focu.Core.Responses;

public class Response<TData>(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
{
    [JsonConstructor]
    public Response() : this(default) {}

    public TData? Data { get; set; } = data;
    public string? Message { get; set; } = message;
    public int Code { get; set; } = code;
    
    [JsonIgnore]
    public Dictionary<string, string[]> ValidationErrors { get; set; } = [];

    [JsonIgnore]
    public bool IsSuccess => Code is >= (int) HttpStatusCode.OK and <= 299;
}