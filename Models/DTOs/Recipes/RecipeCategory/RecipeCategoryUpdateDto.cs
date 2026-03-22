namespace BackendServer.Models.DTOs.Recipes.RecipeCategory;

public class RecipeCategoryUpdateDto
{
    public required Guid Id { get; set; }
    public required string  Name { get; set; }
}