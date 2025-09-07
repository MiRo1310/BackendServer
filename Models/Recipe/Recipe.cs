namespace BackendServer.Models.Recipe;

public class Recipe
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public int? Portions { get; set; }
    

    public int TotalKcal { get; set; } = 0;
    
    public DateTime CreatedAt { get; init; }

    public DateTime? ModifiedAt { get; set; }


    public ICollection<RecipeProduct.RecipeProduct> RecipeProducts { get; init; } = [];

    public ICollection<RecipeDescription.RecipeDescription> RecipeDescriptions { get; init; } = [];

    public ICollection<RecipeProductHeader.RecipeProductHeader> RecipeHeaderProducts { get; init; } = [];
}