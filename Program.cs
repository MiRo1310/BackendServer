using Microsoft.EntityFrameworkCore;
using BackendServer.Data;
using MongoDB.Driver;
using ServerVersion = Microsoft.EntityFrameworkCore.ServerVersion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://192.168.1.10", "http://vis.lan" )
            .AllowAnyHeader()
            .AllowAnyMethod();
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

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDbConnectionString"))
);

builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(builder.Configuration["MongoDb:DatabaseName"]);
});


builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddMongoDbFiltering()
    .AddMongoDbSorting()
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