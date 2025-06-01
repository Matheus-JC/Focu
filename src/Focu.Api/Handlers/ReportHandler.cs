using Focu.Api.Data;
using Focu.Core.Enums;
using Focu.Core.Handlers;
using Focu.Core.Models.Reports;
using Focu.Core.Requests.Reports;
using Focu.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Handlers;

public class ReportHandler(AppDbContext context) : IReportHandler
{
    public async Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(
        GetIncomesAndExpensesRequest request)
    {
        await Task.Delay(1280);
        
        var data = await context
            .IncomesAndExpenses
            .AsNoTracking()
            .Where(x => x.UserId == request.UserId)
            .OrderByDescending(x => x.Year)
            .ThenBy(x => x.Month)
            .ToListAsync();

        return new Response<List<IncomesAndExpenses>?>(data);
    }

    public async Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(
        GetIncomesByCategoryRequest request)
    {
        await Task.Delay(2180);
        
        var data = await context
            .IncomesByCategories
            .AsNoTracking()
            .Where(x => x.UserId == request.UserId)
            .OrderByDescending(x => x.Year)
            .ThenBy(x => x.Category)
            .ToListAsync();

        return new Response<List<IncomesByCategory>?>(data);
    }

    public async Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(
        GetExpensesByCategoryRequest request)
    {
        await Task.Delay(812);
        
        var data = await context
            .ExpensesByCategories
            .AsNoTracking()
            .Where(x => x.UserId == request.UserId)
            .OrderByDescending(x => x.Year)
            .ThenBy(x => x.Category)
            .ToListAsync();

        return new Response<List<ExpensesByCategory>?>(data);
    }

    public async Task<Response<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request)
    {
        await Task.Delay(3280);
        var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        
        var data = await context
            .Transactions
            .AsNoTracking()
            .Where(
                x => x.UserId == request.UserId
                     && x.PaidOrReceivedAt >= startDate
                     && x.PaidOrReceivedAt <= DateTime.Now
            )
            .GroupBy(x => 1)
            .Select(x => new FinancialSummary(
                request.UserId,
                x.Where(ty => ty.Type == TransactionType.Deposit).Sum(t => t.Amount),
                x.Where(ty => ty.Type == TransactionType.Withdraw).Sum(t => t.Amount))
            )
            .FirstOrDefaultAsync();

        return new Response<FinancialSummary?>(data);
    }
}

