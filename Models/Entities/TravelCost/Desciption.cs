using System.ComponentModel.DataAnnotations.Schema;

namespace BackendServer.Models.Entities.Recipes;

public class Description
{
    public Guid Id { get; init; }

    [Column(TypeName = "varchar(255)")] 
    public string Text { get; set; } = "";
}