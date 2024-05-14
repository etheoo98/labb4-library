using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.DbModels;

public class Customer
{
    public int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }

    public ICollection<Loan> Loans { get; set; } = [];
}