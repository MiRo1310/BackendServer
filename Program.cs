using Microsoft.EntityFrameworkCore;
using BackendServer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://192.168.1.10")
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


builder.AddGraphQL().AddSorting().AddTypes().ModifyRequestOptions(options => options.IncludeExceptionDetails = true);

var app = builder.Build();

app.UseCors();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);