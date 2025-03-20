using Focu.Core.Common;

namespace Focu.Core.TransactionDomain.Requests;

public class GetTransactionByIdRequest : Request
{
    public Guid Id { get; set; }
}