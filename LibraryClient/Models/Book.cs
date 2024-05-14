using System.Text.Json.Serialization;

namespace LibraryClient.Models;

public class Book
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("authors")]
    public ICollection<Author> Authors { get; set; } = [];
}