using Focu.Core.Common;

namespace Focu.Core.Requests.Transaction;

public class DeleteTransactionRequest : Request
{
    public Guid Id { get; set; }
}