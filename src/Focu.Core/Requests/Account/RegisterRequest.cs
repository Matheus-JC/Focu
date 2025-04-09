using System.ComponentModel.DataAnnotations;

namespace Focu.Core.Requests.Account;

public class RegisterRequest : Request
{
    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress(ErrorMessage = "Invalid E-mail format")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}