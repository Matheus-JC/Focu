namespace Focu.Core.Models.Reports;

public record ExpensesByCategory(Guid UserId, string Category, int Year, decimal Expenses);