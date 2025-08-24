using BackendServer.Data;
using BackendServer.Models;
using BackendServer.Models.Product;
using BackendServer.Models.ProductUnit;

namespace BackendServer.Types;

[MutationType]
public static class ProductMutation
{
    public static Product CreateProduct(AppDbContext dbContext, ProductCreateDto dto)
    {
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

        if (dto.ProductUnits is not null) ProductUnitHelper.ProcessUnit(dbContext, dto.ProductUnits, product.Id, defaultUnit);

        dbContext.Products.Add(product);
        dbContext.SaveChanges();
        return product;
    }

    public static Product? UpdateProduct(AppDbContext dbContext, ProductUpdateDto dto)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == dto.Id);
        if (product is null) return null;
        product.ModifiedAt = DateTime.UtcNow;
        product.Name = dto.Name ?? product.Name;
        product.Carbs = dto.Carbs;
        product.Category = dto.Category;
        product.Fat = dto.Fat;
        product.Kcal = dto.Kcal;
        product.Protein = dto.Protein;
        product.Salt = dto.Salt;
        product.Sugar = dto.Sugar;
        
        var defaultUnit = dbContext.ProductUnits.FirstOrDefault(unit =>
            unit.ProductId == product.Id && unit.IsDefault == true);
        if (defaultUnit is not null)
        {
            defaultUnit.Amount = dto.Amount;
            defaultUnit.Unit = dto.Unit;
        }
        

        if (dto.ProductUnits is not null) ProductUnitHelper.ProcessUnit(dbContext, dto.ProductUnits, product.Id, defaultUnit);

        dbContext.SaveChanges();
        return product;
    }

    public static bool RemoveProduct(AppDbContext dbContext, Guid id)
    {

        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product is null) return false;
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