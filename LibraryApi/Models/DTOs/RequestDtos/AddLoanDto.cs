using System.Text.Json.Serialization;

namespace LibraryApi.Models.DTOs.RequestDtos;

public class AddLoanDto
{
    [JsonPropertyName("customer-id")]
    public int CustomerId { get; set; }
    
    [JsonPropertyName("book-ids")]
    public HashSet<int> BookIds { get; set; } = [];
}