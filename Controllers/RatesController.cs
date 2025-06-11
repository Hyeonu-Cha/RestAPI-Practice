using Microsoft.AspNetCore.Mvc;
using MinimalRatesApi.Services;

namespace MinimalRatesApi.Controllers;

[ApiController]
[Route("api/[controller]")] // Sets the base route to /api/rates
public class RatesController : ControllerBase
{
    private readonly IRateService _rateService;

    // The IRateService is injected into the controller via the constructor.
    // This follows the Dependency Inversion Principle (the "D" in SOLID).
    // The controller doesn't know about the concrete RateService, only the interface.
    public RatesController(IRateService rateService)
    {
        _rateService = rateService;
    }

    /// <summary>
    /// Gets loan rates based on optional filtering criteria.
    /// </summary>
    /// <param name="loanType">The type of loan (e.g., "owner-occupied").</param>
    /// <param name="term">The loan term in years (e.g., 30).</param>
    /// <returns>A list of matching rates or a 404 Not Found if no rates match.</returns>
    [HttpGet] // This attribute marks the method to handle HTTP GET requests.
    public IActionResult GetRates([FromQuery] string? loanType, [FromQuery] int? term)
    {
        // This controller's only job is to handle the HTTP request and delegate the business logic
        // to the service. This follows the Single Responsibility Principle (the "S" in SOLID).
        var rates = _rateService.GetRates(loanType, term);

        if (!rates.Any())
        {
            // If the service returns no rates, return a 404 Not Found response.
            return NotFound(new { message = "No rates found for the specified criteria." });
        }

        // If rates are found, return a 200 OK with the data.
        return Ok(rates);
    }
}
