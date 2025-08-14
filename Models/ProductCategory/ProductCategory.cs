using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Rezepte.Models;

[Table("productCategories")]
public class ProductCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
}