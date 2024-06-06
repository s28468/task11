namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

public class Visit
{
    public int Id { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int AnimalId { get; set; }

    [Required]
    [Length(1, 100)]
    public required string Date { get; set; }

    [Timestamp]
    public byte[] ConcurrencyToken { get; set; }
    
    public Employee Employee { get; set; } 
    
    public Animal Animal { get; set; }
}