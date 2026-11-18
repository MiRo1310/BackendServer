using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.Models.Entities.IoBroker;

public class ProductUnit
{
    public Guid Id { get; set; }
    
    public Guid UnitId { get; set; }

    [ForeignKey(nameof(UnitId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Unit? Unit { get; set; }
    
    [Column(TypeName = "decimal(12,4)")]
    public decimal? Amount { get; set; }
   
    public Guid ProductId { get; set; }
    
    public bool IsDefault { get; set; }

    public bool Active { get; set; }
    
    [Column(TypeName = "decimal(12,4)")]
    public decimal Faktor { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
    
    public Product? Product { get; set; }
}