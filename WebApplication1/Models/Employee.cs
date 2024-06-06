namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [Length(1, 200)]
    public required string Name { get; set; }

    [Required]
    [Length(1, 20)]
    public required string PhoneNumber { get; set; }

    [Required]
    [Length(1, 200)]
    public required string Email { get; set; }
}