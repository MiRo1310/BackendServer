namespace BackendServer.Models.Recipe;

public class Recipe
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int? Portions { get; set; }
    

    public int TotalKcal { get; set; } = 0;
    
    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }


    public ICollection<RecipeProduct.RecipeProduct> RecipeProducts { get; set; } = [];

    public ICollection<RecipeDescription.RecipeDescription> RecipeDescriptions { get; set; } = [];

    public ICollection<RecipeProductHeader.RecipeProductHeader> RecipeHeaderProducts { get; set; } = [];
}