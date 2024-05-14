using System.Text.Json.Serialization;

namespace LibraryApi.Models.DTOs;

public class BookDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("authors")]
    public ICollection<AuthorDto> AuthorDtos { get; set; } = [];
}