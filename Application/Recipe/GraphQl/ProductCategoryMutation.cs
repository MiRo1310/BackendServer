using BackendServer.Data;
using BackendServer.Enum;
using BackendServer.Models;
using BackendServer.Models.DTOs;
using BackendServer.Models.DTOs.Recipes.ProductCategory;
using BackendServer.Models.Entities.Recipes;

namespace BackendServer.Application.Recipe.GraphQl;

[MutationType]
public static class ProductCategoryMutation
{
    public static Response<ProductCategory> CreateProductCategory(AppDbContext dbContext,
        ProductCategoryCreateDto dto)
    {
        var category = dbContext.ProductCategories.FirstOrDefault(category => category.Name == dto.Name);

        if (category is not null)
            return new Response<ProductCategory>(null, ErrorCode.Exist, true);

        var productCategory = new ProductCategory
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Name = dto.Name
        };
        dbContext.ProductCategories.Add(productCategory);
        dbContext.SaveChanges();

        return new Response<ProductCategory>(productCategory, ErrorCode.Success);
    }

    public static Response<bool> RemoveProductCategory(AppDbContext dbContext, Guid id)
    {
        var productCategory = dbContext.ProductCategories.FirstOrDefault(category => category.Id == id);

        if (productCategory is null)
        {
            return new Response<bool>(false, ErrorCode.NotFound, true);
        };
        
        if(dbContext.Products.Any(p => p.Category == id))
        {
            return new Response<bool>(false, ErrorCode.InUse, true);
        }

        dbContext.ProductCategories.Remove(productCategory);
        dbContext.SaveChanges();
        return new Response<bool>(true, ErrorCode.Success);
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