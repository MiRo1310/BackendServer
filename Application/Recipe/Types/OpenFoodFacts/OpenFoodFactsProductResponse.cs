using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendServer.Application.Recipe.Types.OpenFoodFacts;

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

public class OpenFoodFactsSearchResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; } = 0;
    
    [JsonPropertyName("page")]
    public int Page { get; set; } = 0;
    
    [JsonPropertyName("page_size")]
    public int PageSize { get; set; } = 0;
    
    [JsonPropertyName("page_count")]
    public int PageCount { get; set; } = 0;
    
    [JsonPropertyName("products")]
    public OpenFoodFactProductSearch[] Products { get; set; } =[];
    
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
    public Nutriments? Nutriments { get; set; } = null; 
    
    [JsonExtensionData] 
    public Dictionary<string, JsonElement> AdditionalProductData { get; set; } = [];
}

public class OpenFoodFactProductSearch
{
    [JsonPropertyName("brands")]
    public string? Brands { get; set; }

    [JsonPropertyName("brands_tags")]
    public string[]? BrandsTags { get; set; }
    
    [JsonPropertyName("_id")]
    public string Id { get; set; } = "";
    
    [JsonPropertyName("code")]
    public string Code { get; set; } = ""; 
    
    [JsonPropertyName("categories_tags")]
    public string[]? CategoriesTags { get; set; } = [];
    
    [JsonPropertyName("generic_name_de")]
    public string? GenericNameDe { get; set; } = ""; 
    
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; } = "";
    
    [JsonPropertyName("manufacturing_places_tags")]
    public string[]? ManufacturingPlacesTags { get; set; } = [];
    
    [JsonPropertyName("ingredients_text")]
    public string IngredientsText { get; set; } = ""; 
    
    [JsonExtensionData] 
    public Dictionary<string, JsonElement> AdditionalProductData { get; set; } = [];
}