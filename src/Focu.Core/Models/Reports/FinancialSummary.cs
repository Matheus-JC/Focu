namespace Focu.Core.Models.Reports;

public record FinancialSummary(Guid UserId, decimal Incomes, decimal Expenses)
{
    public decimal Total => Incomes - (Expenses < 0 ? -Expenses : Expenses);
}