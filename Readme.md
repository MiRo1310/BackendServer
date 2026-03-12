# Documentation

## Migration

Create a migration

DbContext options:
- FinanceDbContext
- AppDbContext

```
dotnet ef migrations add {NAME} --context AppDbContext
```

Apply the migration

```
dotnet ef database update --context AppDbContext
```