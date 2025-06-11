using MinimalRatesApi.Models;

namespace MinimalRatesApi.Services;

/// <summary>
/// Defines the contract for a service that provides loan rates.
/// Using an interface allows us to decouple the implementation from the controller,
/// which is essential for testing and maintainability (SOLID).
/// </summary>
public interface IRateService
{
    /// <summary>
    /// Retrieves a collection of rates, optionally filtered by loan type and term.
    /// </summary>
    /// <param name="loanType">The type of loan to filter by.</param>
    /// <param name="term">The term in years to filter by.</param>
    /// <returns>An IEnumerable of Rate objects matching the criteria.</returns>
    IEnumerable<Rate> GetRates(string? loanType, int? term);
}
