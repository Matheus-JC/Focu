namespace Focu.Core.Models.Account;

public class User
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Email { get; set; } = string.Empty;
    public Dictionary<string, string> Claims { get; set; } = [];
}