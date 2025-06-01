namespace Focu.Core.Models.Reports;

public record IncomesAndExpenses(Guid UserId, int Month, int Year, decimal Incomes, decimal Expenses);