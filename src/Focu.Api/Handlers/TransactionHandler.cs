using Focu.Api.Data;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {
        request.StartDate ??= DateTime.Now.GetFirstDayOfMonth();
        request.EndDate ??= DateTime.Now.GetLastDayOfMonth();

        var query = context.Transactions
            .AsNoTracking()
            .Where(x =>
                x.CreatedAt >= request.StartDate &&
                x.CreatedAt <= request.EndDate &&
                x.UserId == request.UserId)
            .OrderBy(x => x.CreatedAt);
        
        var transactions = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        
        var count = await query.CountAsync();
        
        return new PagedResponse<List<Transaction>>(transactions, count, request.PageNumber, request.PageSize);
    }
    
    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        var transaction = await context.Transactions
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == request.Id);
        
        return transaction is null 
            ? new Response<Transaction?>(null, StatusCodes.Status404NotFound, "Transaction not found") 
            : new Response<Transaction?>(transaction);
    }

    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var transaction = new Transaction
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId, 
            CreatedAt = DateTime.Now,
            Amount = request.Amount,
            PaidOrReceivedAt = request.PaidOrReceivedAt,
            Title = request.Title,
            Type = request.Type
        };
        
        await context.Transactions.AddAsync(transaction);
        await context.SaveChangesAsync();

        return new Response<Transaction?>(transaction, StatusCodes.Status201Created, "Transaction created successfully");
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var transaction = await context.Transactions
            .SingleOrDefaultAsync(x => x.Id == request.Id);
        
        if(transaction is null)
            return new Response<Transaction?>(null, StatusCodes.Status404NotFound, "Transaction not found");
        
        transaction.Title = request.Title;
        transaction.Type = request.Type;
        transaction.Amount = request.Amount;
        transaction.CategoryId = request.CategoryId;
        transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
        
        await context.SaveChangesAsync();
        
        return new Response<Transaction?>(transaction, message: "Transaction updated");
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var transaction = await context.Transactions
            .SingleOrDefaultAsync(x => x.Id == request.Id);
        
        if(transaction is null)
            return new Response<Transaction?>(null, StatusCodes.Status404NotFound, "Transaction not found");
        
        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();
        
        return new Response<Transaction?>(transaction, message: "Transaction deleted");
    }
}