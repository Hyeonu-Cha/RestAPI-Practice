using MinimalRatesApi.Services;

// This sets up the main application builder.
var builder = WebApplication.CreateBuilder(args);

// --- Dependency Injection Setup ---
// This tells the application how to create services. When a controller asks for an
// IRateService, the system will provide it with an instance of RateService.
// This is key for SOLID principles, making the code testable and flexible.
builder.Services.AddScoped<IRateService, RateService>();

// --- Add services to the container ---
builder.Services.AddControllers(); // Enables the use of controllers for API endpoints.
builder.Services.AddEndpointsApiExplorer(); // Needed for Swagger to find the API endpoints.
builder.Services.AddSwaggerGen(); // Adds the Swagger documentation generator service.

var app = builder.Build();

// --- Configure the HTTP request pipeline (Middleware) ---
// Middleware processes requests as they come in. The order here is important.
if (app.Environment.IsDevelopment())
{
    // In a development environment, we want to use the helpful Swagger tools.
    app.UseSwagger();
    app.UseSwaggerUI(); // This provides the interactive HTML page for testing the API.
}

//app.UseHttpsRedirection(); // Automatically redirects HTTP requests to HTTPS.

app.MapControllers(); // Maps incoming requests to the correct controller actions.

// This command starts the web server and listens for requests.
app.Run();
