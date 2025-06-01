using System.Net;
using System.Net.Http.Json;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;

namespace Focu.Web.Handlers;

public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
    
    public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {
        const string format = "yyyy-MM-dd";
        
        var startDate = request.StartDate is not null
            ? request.StartDate.Value.ToString(format) 
            : DateTime.Now.GetFirstDayOfMonth().ToString(format);
        
        var endDate = request.EndDate is not null
            ? request.EndDate.Value.ToString(format) 
            : DateTime.Now.GetLastDayOfMonth().ToString(format);
        
        var url = $"v1/transactions?startDate={startDate}&endDate={endDate}";

        return await _client.GetFromJsonAsync<PagedResponse<List<Transaction>>>(url) 
            ?? new PagedResponse<List<Transaction>>(null, (int)HttpStatusCode.BadRequest, "Could not find the transactions");
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request) =>
        await _client.GetFromJsonAsync<Response<Transaction?>>($"v1/transactions/{request.Id}")
            ?? new Response<Transaction?>(null, (int)HttpStatusCode.BadRequest, "Could not find the transaction");

    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/transactions", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>() 
               ?? new Response<Transaction?>(null, (int)result.StatusCode, "Error creating transaction");
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/transactions/{request.Id}", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>() 
               ?? new Response<Transaction?>(null, (int)result.StatusCode, "Error updating transaction");
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var result = await _client.DeleteAsync($"v1/transactions/{request.Id}");
        
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>() 
               ?? new Response<Transaction?>(null, (int)result.StatusCode, "Error deleting transaction");
    }
}