using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryClient.Models.ViewModels;

public class EditCustomerViewModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Must be between 2-100 characters!")]
    [JsonPropertyName("first-name")]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Must be between 2-100 characters!")]
    [JsonPropertyName("last-name")]
    public string LastName { get; set; }
}