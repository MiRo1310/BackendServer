using BackendServer.Application.Recipe.Factories;
using BackendServer.Application.Recipe.Types;
using BackendServer.Application.Recipe.Types.OpenFoodFacts;
using MongoDB.Driver;


namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]
public static class OpenFoodFactsQuery
{
    
    [UseFiltering]
    [UseSorting]
    public static IExecutable<LocalProduct> GetLocalProducts(IMongoDatabase database)
    {
        return database
            .GetCollection<LocalProduct>("products")
            .AsExecutable();
    }
    
    public static async Task<OpenFoodFactsSearchResponse?> GetFoodFactsProductsBySearch(string search)
    {
        return await OpenFoodFactFactory.GetProductsBySearch(search);
    }
    
    public static async Task<OpenFoodFactsProductResponse?> GetFoodFactsProductByCode(string code)
    {
        return await OpenFoodFactFactory.GetProductsByCode(code);
    }    
    
   
}