using BackendServer.Application.IoBroker.Factories;
using BackendServer.Application.IoBroker.Types.OpenFoodFacts;

namespace BackendServer.Application.IoBroker.GraphQl;

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