namespace MinimalRatesApi.Models;

/// <summary>
/// Represents a single loan interest rate product.
/// This is a simple data object (POCO) to hold our data.
/// </summary>
public class Rate
{
    public required string ProductName { get; set; }
    public required string LoanType { get; set; } // e.g., "Owner-Occupied", "Investment"
    public int TermInYears { get; set; }
    public double InterestRate { get; set; }
}
