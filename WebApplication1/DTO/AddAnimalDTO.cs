namespace WebApplication1.DTO;
using System.ComponentModel.DataAnnotations;


public class AddAnimalDTO
{
    [Required]
    [Length(1, 100)]
    public required string Name { get; set; }

    [Length(0, 2000)]
    public string? Description { get; set; }

    [Required]
    public required string AnimalType { get; set; }
}