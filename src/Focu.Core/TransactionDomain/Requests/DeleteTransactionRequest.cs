using Focu.Core.Common;

namespace Focu.Core.TransactionDomain.Requests;

public class DeleteTransactionRequest : Request
{
    public Guid Id { get; set; }
}