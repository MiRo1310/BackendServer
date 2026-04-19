using System.Text.Json;
using BackendServer.Application.Common;
using BackendServer.Application.Enum;
using BackendServer.Application.Recipe.Types;

namespace BackendServer.Application.Recipe.Factories;

public class OpenFoodFactFactory
{
    private static readonly HttpClient Client = new();

    public static async Task<string> GetProductsBySearch(string search)
    {
        if (search == "")
        {
            return string.Empty;
        }

        var url = $"https://world.openfoodfacts.org/cgi/search.pl?search_terms={search}&search_simple=1&json=1";

        var response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return json;
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

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonHelper.Deserialize<OpenFoodFactsProductResponse>(json);

        if (result?.OpenFoodFactProduct == null)
        {
            GraphQlErrorHandler.Custom("Produkt nicht gefunden oder ungültige Antwort", ErrorCode.NotFound);
            
        }
       

        return result;
    }
}