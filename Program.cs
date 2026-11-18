using Microsoft.EntityFrameworkCore;
using BackendServer.Data;
using ServerVersion = Microsoft.EntityFrameworkCore.ServerVersion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173","http://localhost:5174", "http://192.168.1.10", "http://vis.lan" )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Feste Server-Version statt ServerVersion.AutoDetect: AutoDetect öffnet schon beim
// Auflösen des DbContext eine Verbindung und lässt den Start crashen, wenn die DB
// (noch) nicht erreichbar ist. Überschreibbar per Konfiguration "MySqlServerVersion",
// z. B. "8.0.36-mysql" oder "10.11.6-mariadb".
var mySqlServerVersion = ServerVersion.Parse(builder.Configuration["MySqlServerVersion"] ?? "8.0.0-mysql");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("AppDbConnectionString"),
        mySqlServerVersion,
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("FinanceDbConnectionString"),
        mySqlServerVersion,
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddTypes()
    .ModifyCostOptions(o => o.EnforceCostLimits = false)
    .ModifyRequestOptions(options => options.IncludeExceptionDetails = true);

var app = builder.Build();

if (app.Environment.IsProduction())
{
    // Beim Start warten, bis die DB erreichbar ist, statt sofort abzustürzen.
    const int maxAttempts = 10;
    for (var attempt = 1; ; attempt++)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
            scope.ServiceProvider.GetRequiredService<FinanceDbContext>().Database.Migrate();
            break;
        }
        catch (Exception ex) when (attempt < maxAttempts)
        {
            var delay = TimeSpan.FromSeconds(Math.Min(5 * attempt, 30));
            app.Logger.LogWarning(ex, "Datenbank-Migration fehlgeschlagen (Versuch {Attempt}/{Max}), neuer Versuch in {Delay}s",
                attempt, maxAttempts, delay.TotalSeconds);
            Thread.Sleep(delay);
        }
    }
}

app.UseCors();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);