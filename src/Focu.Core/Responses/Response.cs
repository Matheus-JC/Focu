using System.Net;
using System.Text.Json.Serialization;
using Focu.Core.Common;

namespace Focu.Core.Responses;

public class Response<TData>(TData? data, int code = Configuration.DefaultStatusCode, string message = "")
{
    [JsonConstructor]
    public Response() : this(default) {}

    public TData? Data { get; } = data;
    public string Message { get; } = message;
    public int Code { get; } = code;
    
    [JsonIgnore]
    public Dictionary<string, string[]> ValidationErrors { get; } = [];

    [JsonIgnore]
    public bool IsSuccess => Code is >= (int) HttpStatusCode.OK and <= 299;
}