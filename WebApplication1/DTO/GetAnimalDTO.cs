namespace WebApplication1.DTO;
using System.Text.Json.Serialization;

using System.ComponentModel.DataAnnotations;
public class GetAnimalDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Id { get; set; }
    public required string Name { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    public required string AnimalType { get; set; }
}