using System.Text.Json.Serialization;

namespace LibraryClient.Models.ViewModels;

public class CreateLoanViewModel
{
    [JsonPropertyName("customer-id")]
    public int CustomerId { get; set; }
    
    [JsonPropertyName("book-ids")]
    public int[] BookIds { get; set; } = [];
}