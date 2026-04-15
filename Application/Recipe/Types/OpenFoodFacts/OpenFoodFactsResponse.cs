using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendServer.Application.Recipe.Types;

public class OpenFoodFactsResponse
{
  //  [JsonPropertyName("products")]
    //public List<OpenFoodFactProduct>? OpenFoodFactProducts { get; set; }
    
  //  public int Page { get; set; }
    
   // [JsonPropertyName("page_size")]
   // public int PageSize { get; set; }
    
   // [JsonPropertyName("page_count")]
   // public int pageCount { get; set; }
    
    public int count { get; set; }

    [JsonExtensionData] public Dictionary<string, JsonElement> AdditionalData { get; set; } = [];
}

/*public class OpenFoodFactProduct
{
    [JsonPropertyName("product_name")]
    public string? ProductName { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }
}*/