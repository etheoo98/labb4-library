using System.Text.Json.Serialization;

namespace LibraryClient.Models;

public class Loan
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
    public ICollection<Book> Book { get; set; } = [];
}