using Focu.Core.Common;
using Focu.Core.Models;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;

namespace Focu.Core.Handlers;

public interface ITransactionHandler
{
    Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
    Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
    Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
    Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
}