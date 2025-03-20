using Focu.Core.Common;
using Focu.Core.TransactionDomain.Requests;

namespace Focu.Core.TransactionDomain;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> GetByIdAsync(GetTransactionsByPeriodRequest request);
    Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
    Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
    Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
}