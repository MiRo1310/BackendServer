using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.Recipe.Types.OpenFoodFacts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendServer.Application.Recipe.Factories;

public class OpenFoodFactFactory
{
    private static readonly HttpClient Client = new();

    public static async Task<List<LocalProduct>?> GetProductsByLocalSearch(IMongoDatabase database, string search, int? page =1)
    {
        if (search == "")
        {
            return null;
        }
       var products = database.GetCollection<LocalProduct>("products");
        
        var filter = Builders<LocalProduct>.Filter.Regex("product_name", new BsonRegularExpression(search, "i"));
        return await products.Find(filter).Limit(20).ToListAsync();
    }
    
    public static async Task<OpenFoodFactsSearchResponse?> GetProductsBySearch(string search, int? page =1)
    {
        if (search == "")
        {
            return null;
        }

        /*var url = $"https://world.openfoodfacts.org/cgi/search.pl?search_terms={search}&search_simple=1&json=1&page={page}";*/
        /*var url = $"https://world.openfoodfacts.org/api/v2/search?search_terms={search}&search_simple=1&json=1&page={page}";*/
        var url = $"https://world.openfoodfacts.org/api/v2/search?search_terms={search}";
   Client.DefaultRequestHeaders.UserAgent.ParseAdd("TestApp/1.0 (mailto:deine@email.de)");

        var response = await Client.GetAsync(url);
        GraphQlErrorHandler.HttpResponse(response);

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonHelper.Deserialize<OpenFoodFactsSearchResponse>(json);
        return result;
    }

    public static async Task<OpenFoodFactsProductResponse?> GetProductsByCode(string code)
    {
        if (code == "")
        {
            return null;
        }

        var url = $"https://world.openfoodfacts.org/api/v0/product/{code}.json";

        var response = await Client.GetAsync(url);
        GraphQlErrorHandler.HttpResponse(response);
        


        var json = await response.Content.ReadAsStringAsync();
        var result = JsonHelper.Deserialize<OpenFoodFactsProductResponse>(json);

        if (result?.OpenFoodFactProduct == null)
        {
            GraphQlErrorHandler.Custom("Produkt nicht gefunden oder ungültige Antwort", ErrorCode.NotFound);
            
        }
       

        return result;
    }
}