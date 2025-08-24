namespace BackendServer.Models.RecipeProduct;

public class RecipeProduct
{
    public Guid Id { get; set; }
    
    public Guid RecipeId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public string Description { get; set; }
    
    public decimal? Amount { get; set; }
    
    public string Unit { get; set; }
    
    public int ProductPosition { get; set; }
    
    public int GroupPosition { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public decimal? Factor { get; set; }
    
    public Recipe.Recipe? Recipe { get; set; }
    
    public Product.Product Product { get; set; }
}