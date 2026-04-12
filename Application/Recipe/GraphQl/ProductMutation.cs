using BackendServer.Application.Recipe.Factories;
using BackendServer.Data;
using BackendServer.Enum;
using BackendServer.Models.DTOs;
using BackendServer.Models.Entities.Recipes;
using BackendServer.Models.Product;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class ProductMutation
{
    public static Response<Product> CreateProduct(AppDbContext dbContext, ProductCreateDto dto)
    {
        var productNameExists = dbContext.Products.Any(p => p.Name == dto.Name);
        if (productNameExists)
        {
            return new Response<Product>(null, ErrorCode.Exist, true);
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
            Amount = dto.Amount
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

        return new Response<Product>(product, ErrorCode.Success);
    }

    public static Response<Product?> UpdateProduct(AppDbContext dbContext, ProductUpdateDto dto)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == dto.Id);
        if (product is null)
        {
            return new Response<Product?>(null, ErrorCode.NotFound, true);
        }
        
        var productNameExists = dbContext.Products.Any(p => p.Name == dto.Name && p.Id != dto.Id);
        if (productNameExists)
        {
            return new Response<Product?>(null, ErrorCode.Exist, true);
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

        return new Response<Product?>(product, ErrorCode.Success);
    }

    public static Response<bool> RemoveProduct(AppDbContext dbContext, Guid id)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return new Response<bool>(false, ErrorCode.NotFound, true);
        }

        if (dbContext.RecipeProducts.Any(rp => rp.ProductId == id))
        {
            return new Response<bool>(false, ErrorCode.InUse, true);
        }

        var units = dbContext.ProductUnits.Where(unit => unit.ProductId == id);

        foreach (var productUnit in units)
        {
            dbContext.ProductUnits.Remove(productUnit);
        }

        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
        return new Response<bool>(true, ErrorCode.Success);
    }
}