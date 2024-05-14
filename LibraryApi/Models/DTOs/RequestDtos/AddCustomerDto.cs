using System.Text.Json.Serialization;

namespace LibraryApi.Models.DTOs.RequestDtos;

public class AddCustomerDto
{
    [JsonPropertyName("first-name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("last-name")]
    public string LastName { get; set; }
}