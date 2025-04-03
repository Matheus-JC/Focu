using Focu.Core.Common;

namespace Focu.Core.Requests.Transaction;

public class GetTransactionsByPeriodRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}