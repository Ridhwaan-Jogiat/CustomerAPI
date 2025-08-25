using CustomerAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure database (SQLite)
// Uses environment variable if provided (for hosted), otherwise local file
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") 
                       ?? "Data Source=customer.db";
builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseSqlite(connectionString));

// Configure CORS to allow both local and hosted frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:4200",                // Angular dev server
                "https://customer-app-iota.vercel.app"  // hosted frontend
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Swagger for development only
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

// Ensure SQLite database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CustomerContext>();
    context.Database.EnsureCreated();
}

// Use dynamic port for Render; default to 5000 for local
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
