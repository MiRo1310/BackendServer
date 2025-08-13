using System.ComponentModel.DataAnnotations.Schema;

namespace Rezepte.Models;

[Table("units")]
public class Unit
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
}