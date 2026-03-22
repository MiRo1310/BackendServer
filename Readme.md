# Documentation

## Migration

Eine Migration erstellen

DbContext options:
- FinanceDbContext
- AppDbContext

```
dotnet ef migrations add {NAME} --context AppDbContext
```

Die Migration anwenden

```
dotnet ef database update --context AppDbContext
```

Eine SQL-Skript aus der Migration generieren, um die Migration manuell auf der Datenbank auszuführen, bzw zu sehen was die Migration macht.

```
 dotnet ef migrations script --context AppDbContext --output migration.sql
```
