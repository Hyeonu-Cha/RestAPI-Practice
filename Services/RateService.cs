using MinimalRatesApi.Models;

namespace MinimalRatesApi.Services;

/// <summary>
/// Concrete implementation of IRateService that provides static, mock loan rate data.
/// This class has a single responsibility: providing rate data.
/// </summary>
public class RateService : IRateService
{
    // In a real application, this data would come from a database or another API.
    // For this task, we are using a static list to provide mock data.
    private readonly List<Rate> _allRates = new()
    {
        new Rate { ProductName = "Fixed Rate Home Loan", LoanType = "Owner-Occupied", TermInYears = 30, InterestRate = 6.15 },
        new Rate { ProductName = "Variable Rate Home Loan", LoanType = "Owner-Occupied", TermInYears = 30, InterestRate = 6.45 },
        new Rate { ProductName = "Fixed Rate Investment Loan", LoanType = "Investment", TermInYears = 30, InterestRate = 6.55 },
        new Rate { ProductName = "Fixed Rate Home Loan", LoanType = "Owner-Occupied", TermInYears = 15, InterestRate = 5.99 },
        new Rate { ProductName = "Fixed Rate Investment Loan", LoanType = "Investment", TermInYears = 15, InterestRate = 6.25 }
    };

    /// <summary>
    /// Retrieves rates and filters them based on the provided criteria.
    /// </summary>
    public IEnumerable<Rate> GetRates(string? loanType, int? term)
    {
        // Start with the full list of rates.
        var filteredRates = _allRates.AsEnumerable();

        // If a loanType is provided, filter the list.
        // We use StringComparison.OrdinalIgnoreCase for a case-insensitive match.
        // We also replace the hyphen from the URL to match our data model.
        if (!string.IsNullOrEmpty(loanType))
        {
            var formattedLoanType = loanType.Replace("-", " ");
            filteredRates = filteredRates.Where(r => r.LoanType.Equals(formattedLoanType, StringComparison.OrdinalIgnoreCase));
        }

        // If a term is provided, further filter the list.
        if (term.HasValue)
        {
            filteredRates = filteredRates.Where(r => r.TermInYears == term.Value);
        }

        return filteredRates.ToList();
    }
}
