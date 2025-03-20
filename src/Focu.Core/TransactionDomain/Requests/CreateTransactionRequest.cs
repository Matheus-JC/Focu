using System.ComponentModel.DataAnnotations;
using Focu.Core.Common;

namespace Focu.Core.TransactionDomain.Requests;

public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Invalid Title")]
    [MaxLength(80, ErrorMessage = "title must contain up to 80 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Invalid Type")]
    public TransactionType Type { get; set; }
    
    public decimal Amount { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public DateTime? PaidOrReceivedAt { get; set; }
}