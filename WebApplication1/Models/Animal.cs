using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Animal
{
    public int Id { get; set; }
    
    [Required]
    [Length(1, 100)]
    public required string Name { get; set; }

    [Length(0, 2000)]
    public string? Description { get; set; }
    
    [Required]
    public int AnimalTypesId { get; set; }
    
    public AnimalTypes AnimalType { get; set; }
    
    [Timestamp]
    public byte[] ConcurrencyToken { get; set; }
}