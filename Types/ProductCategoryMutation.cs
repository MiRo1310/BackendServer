using System.Runtime.InteropServices.JavaScript;
using Rezepte.Data;
using Rezepte.Enum;
using Rezepte.Models;

namespace Rezepte.Types;

[MutationType]

public static class ProductCategoryMutation
{
        public static ResponseObject<ProductCategory> CreateProductCategory(AppDbContext dbContext, ProductCategoryCreateDto dto)
        {
            var category = dbContext.ProductCategories.FirstOrDefault(category => category.Name == dto.Name);

            if (category is not null)
            {
                return new ResponseObject<ProductCategory>(null, ErrorCode.Exist, true );
            }
                
            var productCategory = new ProductCategory()
            {
                CreatedAt = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                Name = dto.Name
            };
            dbContext.Add(productCategory);
            dbContext.SaveChanges();

            return new ResponseObject<ProductCategory>(productCategory,ErrorCode.Success,false );
        }

        public static bool RemoveProductCategory(AppDbContext dbContext, Guid id)
        {
            var productCategory = dbContext.ProductCategories.FirstOrDefault(category => category.Id == id);

            if (productCategory is null)
            {
                return false;
            }

            dbContext.ProductCategories.Remove(productCategory);
            dbContext.SaveChanges();
            return true;
        }


        public static ProductCategory? UpdateProductCategory(AppDbContext dbContext, ProductCategoriesUpdateDto dto)
        {
            var productCategory = dbContext.ProductCategories.FirstOrDefault(category => category.Id == dto.Id);

            if (productCategory is null)
            {
                return null;
            }

            productCategory.Name = dto.Name;
            
            dbContext.SaveChanges();
            return productCategory;
        }
}