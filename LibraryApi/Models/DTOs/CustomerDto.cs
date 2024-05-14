using System.Text.Json.Serialization;

namespace LibraryApi.Models.DTOs;

public class CustomerDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("first-name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("last-name")]
    public string LastName { get; set; }

    [JsonPropertyName("loans")]
    public ICollection<LoanDto> LoanDtos { get; set; } = [];
}