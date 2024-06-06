namespace WebApplication1.DTO;
using System.ComponentModel.DataAnnotations;

public class AddVisitDTO
{
    [Required]
    public int EmployeeId { get; set; }
    
    [Required]
    public int AnimalId { get; set; }
    
    [Required]
    [Length(1, 100)]
    public required string Date { get; set; }
}