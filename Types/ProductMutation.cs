using Rezepte.Data;
using Rezepte.Models;
using Rezepte.Models.Product;

namespace Rezepte.Types;

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
            Amount = dto.Amount,
            Unit = dto.Unit ?? ""
        };

        if (dto.ProductUnits is not null) ProductUnitHelper.ProcessUnit(dbContext, dto.ProductUnits, product.Id);

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
        product.Amount = dto.Amount;
        product.Unit = dto.Unit ?? "";

        if (dto.ProductUnits is not null) ProductUnitHelper.ProcessUnit(dbContext, dto.ProductUnits, product.Id);

        dbContext.SaveChanges();
        return product;
    }

    public static bool RemoveProduct(AppDbContext dbContext, Guid id)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product is null) return false;

        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
        return true;
    }
}