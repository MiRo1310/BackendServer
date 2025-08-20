using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Unit;

public class Unit
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
}