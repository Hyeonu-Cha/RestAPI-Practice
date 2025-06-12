# Minimal Loan Rates API

This is a minimal .NET 8 Web API created to demonstrate a simple, well-structured service. It exposes a single endpoint to retrieve mock home loan interest rates.

## Features

* **.NET 8 Minimal API:** Built using the modern, clean structure of .NET 8.
* **SOLID Principles:** The solution is structured using services and interfaces to demonstrate Dependency Inversion and Single Responsibility.
* **Dependency Injection:** Uses .NET's built-in dependency injection container for loose coupling.
* **Swagger/OpenAPI:** Includes auto-generated API documentation for easy testing and exploration.

## Endpoint

### Get Loan Rates

Returns a list of available loan rates based on optional query parameters.

-   **URL:** `/api/rates`
-   **Method:** `GET`
-   **Query Parameters:**
    -   `loanType` (string, optional): Filters rates by the type of loan. Valid values: `owner-occupied` or `investment`.
    -   `term` (int, optional): Filters rates by the loan term in years. Example: `30`.
-   **Success Response (200 OK):**
    ```json
    [
      {
        "productName": "Fixed Rate Home Loan",
        "loanType": "Owner-Occupied",
        "termInYears": 30,
        "interestRate": 6.15
      }
    ]
    ```
-   **Not Found Response (404 Not Found):**
    ```json
    {
      "message": "No rates found for the specified criteria."
    }
    ```

## How to Run

1.  **Prerequisites:**
    * [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) must be installed.
2.  **Navigate to the project folder:**
    ```sh
    cd path/to/RestAPI Practice
    ```
3.  **Run the Application:**
    ```sh
    dotnet run
    ```
4.  The API will be running on a local port (e.g., `http://localhost:5000`). Nothing will be posted for this version.
5.  Open your browser and navigate to `/swagger` on that URL (e.g., `http://localhost:5000/swagger`) to view the documentation.

## Project Structure

The project uses a standard, feature-oriented structure to separate concerns, making it clean and easy to maintain.

```
/RestAPI Practice
│
├── Properties/
│   └── launchSettings.json   # Configures how the app starts in Development vs. Production.
│
├── Controllers/
│   └── RatesController.cs      # Handles incoming HTTP requests and responses.
│
├── Models/
│   └── Rate.cs                 # Defines the data structure for a loan rate.
│
├── Services/
│   ├── IRateService.cs         # The interface (contract) for the Rate service.
│   └── RateService.cs          # The concrete implementation of the service; contains business logic.
│
├── MinimalRatesApi.csproj      # The .NET project file; defines dependencies (e.g., Swagger).
├── Program.cs                  # The main entry point of the application; configures services and middleware.
└── README.md                   # This file.
