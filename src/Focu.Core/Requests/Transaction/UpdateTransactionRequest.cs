using System.ComponentModel.DataAnnotations;
using Focu.Core.Common;
using Focu.Core.Enums;

namespace Focu.Core.Requests.Transaction;

public class UpdateTransactionRequest : Request
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Invalid Title")]
    [MaxLength(80, ErrorMessage = "title must contain up to 80 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Invalid Type")]
    public TransactionType Type { get; set; }
    
    public decimal Amount { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public DateTime? PaidOrReceivedAt { get; set; }
}