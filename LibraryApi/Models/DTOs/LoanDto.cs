using System.Text.Json.Serialization;
using LibraryApi.Models.DbModels;

namespace LibraryApi.Models.DTOs;

public class LoanDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
        
    [JsonPropertyName("customer-id")]
    public int CustomerId { get; set; }
    
    [JsonPropertyName("loan-date")]
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
    
    [JsonPropertyName("return-date")]
    public DateTime? ReturnDate { get; set; }
    
    [JsonPropertyName("books")]
    public ICollection<BookDto> BookDtos { get; set; } = [];
}