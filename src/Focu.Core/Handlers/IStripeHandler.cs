using Focu.Core.Requests.Stripe;
using Focu.Core.Responses;
using Focu.Core.Responses.Stripe;

namespace Focu.Core.Handlers;

public interface IStripeHandler
{
    Task<Response<string?>> CreateSessionAsync(CreateSessionRequest request);
    Task<Response<List<StripeTransactionResponse>>> GetTransactionsByOrderNumberAsync(GetTransactionByOrderNumberRequest request);
}