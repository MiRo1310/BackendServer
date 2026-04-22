using BackendServer.Application.Enum;
using BackendServer.Application.Recipe.Factories;
using BackendServer.Application.Recipe.Types.OpenFoodFacts;
using MongoDB.Driver;


namespace BackendServer.Application.Recipe.GraphQl;

[QueryType]
public static class OpenFoodFactsQuery
{
    
    [UseOffsetPaging]
    [UseProjection(Scope = nameof(GraphQlScope.MongoDb))]
    [UseFiltering(Scope = nameof(GraphQlScope.MongoDb))]
    [UseSorting(Scope = nameof(GraphQlScope.MongoDb))]
    
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