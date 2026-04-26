using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Data;
using BackendServer.Models;
using BackendServer.Models.DTOs.Recipes.ProductCategory;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class ProductCategoryMutation
{
    public static ProductCategory? CreateProductCategory(AppDbContext dbContext,
        ProductCategoryCreateDto dto)
    {
        var category = dbContext.ProductCategories.FirstOrDefault(category => category.Name == dto.Name);

        if (category is not null)
        {
            GraphQlErrorHandler.Custom("Kategorie existiert und kann daher nicht angelegt werden", ErrorCode.Exist);
            return null;
        }

        var productCategory = new ProductCategory
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name
        };
        dbContext.ProductCategories.Add(productCategory);
        dbContext.SaveChanges();

        return productCategory;
    }

    public static bool RemoveProductCategory(AppDbContext dbContext, Guid id)
    {
        var productCategory = dbContext.ProductCategories.FirstOrDefault(category => category.Id == id);

        if (productCategory is null)
        {
            GraphQlErrorHandler.Custom("Kategorie wurde nicht gefunden", ErrorCode.NotFound);
            return false;
        };
        
        if(dbContext.Products.Any(p => p.Category == id))
        {
            GraphQlErrorHandler.Custom("Kategorie wird schon genutzt, und kann daher nicht gelöscht werden", ErrorCode.InUse);
            return false;
        }

        dbContext.ProductCategories.Remove(productCategory);
        dbContext.SaveChanges();
        return true;
    }


    public static ProductCategory? UpdateProductCategory(AppDbContext dbContext, ProductCategoryUpdateDto dto)
    {
        var productCategory = dbContext.ProductCategories.FirstOrDefault(category => category.Id == dto.Id);

        if (productCategory is null) return null;

        productCategory.Name = dto.Name;

        dbContext.SaveChanges();
        return productCategory;
    }
}