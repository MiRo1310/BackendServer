using Microsoft.EntityFrameworkCore;
using BackendServer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("AppDbConnectionString"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("AppDbConnectionString"))
    )
);

builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("FinanceDbConnectionString"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("FinanceDbConnectionString"))
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
    using var scope = app.Services.CreateScope();
    var appDb = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var financeDb = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();

    appDb.Database.Migrate();
    financeDb.Database.Migrate();
}

app.UseCors();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);