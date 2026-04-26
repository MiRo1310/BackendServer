using BackendServer.Application.Recipe.Factories;
using BackendServer.Application.Recipe.Types.OpenFoodFacts;

namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]
public static class OpenFoodFactsQuery
{
    public static async Task<OpenFoodFactsSearchResponse?> GetFoodFactsProductsBySearch(string search)
    {
        return await OpenFoodFactFactory.GetProductsBySearch(search);
    }
    
    public static async Task<OpenFoodFactsProductResponse?> GetFoodFactsProductByCode(string code)
    {
        return await OpenFoodFactFactory.GetProductsByCode(code);
    }    
    
   
}