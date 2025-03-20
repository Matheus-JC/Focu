using Focu.Core.Common;

namespace Focu.Core.TransactionDomain.Requests;

public class GetTransactionsByPeriodRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}