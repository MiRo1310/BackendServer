using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendServer.Application.Recipe.Types;

public class OpenFoodFactsProductResponse
{
    [JsonPropertyName("product")]
    public OpenFoodFactProduct? OpenFoodFactProduct { get; set; }
    
    [JsonPropertyName("code")]
    public string Code { get; set; } = ""; 
    
    [JsonPropertyName("status_verbose")]
    public string? StatusVerbose { get; set; } = null;
    
    [JsonPropertyName("status")]
    public int? Status { get; set; } = null;

    [JsonExtensionData] 
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = [];
}

public class OpenFoodFactProduct
{
    [JsonPropertyName("brands")]
    public string? Brands { get; set; }

   [JsonPropertyName("brands_tags")]
    public string[]? BrandsTags { get; set; }
    
    [JsonPropertyName("code")]
    public string Code { get; set; } = ""; 
    
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";
    
    [JsonPropertyName("ingredients_text")]
    public string IngredientsText { get; set; } = ""; 
    
    [JsonPropertyName("nutriments")]
    public Nutriments? Nutriments { get; set; }
    
    [JsonExtensionData] 
    public Dictionary<string, JsonElement> AdditionalProductData { get; set; } = [];
}

