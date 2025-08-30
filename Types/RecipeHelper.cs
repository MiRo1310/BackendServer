using BackendServer.Data;
using BackendServer.Models.RecipeProduct;

namespace BackendServer.Types;

public class RecipeHelper
{
    public static int GetTotalKcal(ICollection<RecipeProduct> recipeProducts)
    {
        return recipeProducts.Sum(rp => rp!.Kcal);
    }
}