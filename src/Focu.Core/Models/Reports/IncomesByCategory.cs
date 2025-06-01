namespace Focu.Core.Models.Reports;

public record IncomesByCategory(Guid UserId, string Category, int Year, decimal Incomes);