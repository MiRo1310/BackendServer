using Microsoft.AspNetCore.Routing.Constraints;

namespace Rezepte.Models;

public class ProductCategories
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}