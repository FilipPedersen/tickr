using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<FinancialDataService>();
builder.Services.AddSingleton(sp => 
{
    var client = new Client("https://tshupdoxlczxihaoitcg.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRzaHVwZG94bGN6eGloYW9pdGNnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTE5MTExMzUsImV4cCI6MjA2NzQ4NzEzNX0.4fI7ZNj5YE15wSYSqm9ZmzT24JPfvnj6-qY3mL5RLPc");
    client.InitializeAsync().GetAwaiter().GetResult();
    return client;
});

    // new SupabaseService("https://tshupdoxlczxihaoitcg.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRzaHVwZG94bGN6eGloYW9pdGNnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTE5MTExMzUsImV4cCI6MjA2NzQ4NzEzNX0.4fI7ZNj5YE15wSYSqm9ZmzT24JPfvnj6-qY3mL5RLPc"));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(",");
builder.Services.Configure<FinancialModelingPrepSettings>(builder.Configuration.GetSection("financialModelingPrep"));

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
        });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();

public class FinancialModelingPrepSettings
{
    public string ApiKey { get; set; } = String.Empty;
    public string BaseUrl { get; set; } = String.Empty;
}