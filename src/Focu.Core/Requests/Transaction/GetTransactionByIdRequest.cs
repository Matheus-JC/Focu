using Focu.Core.Common;

namespace Focu.Core.Requests.Transaction;

public class GetTransactionByIdRequest : Request
{
    public Guid Id { get; set; }
}