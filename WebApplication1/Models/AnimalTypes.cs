using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class AnimalTypes
{
    public int Id { get; set; }
    
    [Length(1, 150)]
    [Required]
    public required string Name { get; set; }
}