using Microsoft.EntityFrameworkCore;
using Rezepte.Data;

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
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.AddGraphQL().AddTypes().ModifyRequestOptions(options => options.IncludeExceptionDetails = true);

var app = builder.Build();

app.UseCors();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);
