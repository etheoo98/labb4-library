using System.Text.Json.Serialization;

namespace LibraryClient.Models;

public class Author
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("first-name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("last-name")]
    public string LastName { get; set; }
}