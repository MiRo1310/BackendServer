using Microsoft.EntityFrameworkCore;
using BackendServer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
var connectionStringFinance = builder.Configuration.GetConnectionString("FinanceDbConnectionString");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseMySql(connectionStringFinance, ServerVersion.AutoDetect(connectionStringFinance)));

if (args.Length == 0 || args[0] != "ef") 
{
    using (var scope = builder.Services.BuildServiceProvider().CreateScope())
    {
        var financeDb = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
        financeDb.Database.Migrate();

        var recipeDb = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        recipeDb.Database.Migrate();
    }
}


builder.AddGraphQL().AddSorting().AddTypes().ModifyRequestOptions(options => options.IncludeExceptionDetails = true);

var app = builder.Build();

app.UseCors();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);