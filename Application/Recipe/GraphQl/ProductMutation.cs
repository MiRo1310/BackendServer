using BackendServer.Application.Common;
using BackendServer.Application.Recipe.Factories;
using BackendServer.Data;
using BackendServer.Enum;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.Product;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class ProductMutation
{
    public static Product? CreateProduct(AppDbContext dbContext, ProductCreateDto dto)
    {
        var productNameExists = dbContext.Products.Any(p => p.Name == dto.Name);
        if (productNameExists)
        {
            GraphQlErrorHandler.Custom("Produktname existiert schon", ErrorCode.InUse);
            return null;
        }

        var product = new Product
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Carbs = dto.Carbs,
            Category = dto.Category,
            Fat = dto.Fat,
            Kcal = dto.Kcal,
            Protein = dto.Protein,
            Salt = dto.Salt,
            Sugar = dto.Sugar,
            Unit = dto.Unit,
            Amount = dto.Amount,
            Ean = dto.Ean
        };
        
        var defaultUnit = new ProductUnit()
        {
            Amount = dto.Amount,
            IsDefault = true,
            ProductId = product.Id,
            Unit = dto.Unit,
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Faktor = 1
        };
        dbContext.ProductUnits.Add(defaultUnit);

        if (dto.ProductUnits is not null)
            ProductUnitFactory.ProcessUnit(dbContext, dto.ProductUnits, product.Id, defaultUnit);

        dbContext.Products.Add(product);
        dbContext.SaveChanges();

        return product;
    }

    public static Product? UpdateProduct(AppDbContext dbContext, ProductUpdateDto dto)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == dto.Id);
        if (product is null)
        {
            GraphQlErrorHandler.Custom("Produkt wurde nicht gefunden", ErrorCode.NotFound);
            return null;
        }
        
        var productNameExists = dbContext.Products.Any(p => p.Name == dto.Name && p.Id != dto.Id);
        if (productNameExists)
        {
            GraphQlErrorHandler.Custom("Produkt existiert bereits", ErrorCode.Exist);
            return null;
        }

        product.ModifiedAt = DateTime.UtcNow;
        product.Name = dto.Name ?? product.Name;
        product.Carbs = dto.Carbs;
        product.Category = dto.Category;
        product.Fat = dto.Fat;
        product.Kcal = dto.Kcal;
        product.Protein = dto.Protein;
        product.Salt = dto.Salt;
        product.Sugar = dto.Sugar;
        product.Unit = dto.Unit ?? "";
        product.Amount = dto.Amount ?? 0;
        product.Ean = dto.Ean ?? product.Ean;

        var defaultUnit = dbContext.ProductUnits.FirstOrDefault(unit =>
            unit.ProductId == product.Id && unit.IsDefault == true);
        if (defaultUnit is not null)
        {
            defaultUnit.Amount = dto.Amount;
            defaultUnit.Unit = dto.Unit ?? "";
        }

        if (dto.ProductUnits is not null)
            ProductUnitFactory.ProcessUnit(dbContext, dto.ProductUnits, product.Id, defaultUnit);

        dbContext.SaveChanges();

        return product;
    }

    public static bool RemoveProduct (AppDbContext dbContext, Guid id)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            GraphQlErrorHandler.Custom("Produkt wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        }

        if (dbContext.RecipeProducts.Any(rp => rp.ProductId == id))
        {
            GraphQlErrorHandler.Custom("Produkt kann nicht geglöscht werden", ErrorCode.InUse);
            return false;
        }

        var units = dbContext.ProductUnits.Where(unit => unit.ProductId == id);

        foreach (var productUnit in units)
        {
            dbContext.ProductUnits.Remove(productUnit);
        }

        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
        return true;
    }
}