namespace WebApplication1.DTO;
using System.Text.Json.Serialization;

public class GetVisitDTO
{
    public int Id { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? EmployeeId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? AnimalId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EmployeeName { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? AnimalName { get; set; }
    public required string Date { get; set; }
}