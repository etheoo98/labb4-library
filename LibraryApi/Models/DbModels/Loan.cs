using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models.DbModels;

public class Loan
{
    public int Id { get; set; }
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnDate { get; set; }
    
    [ForeignKey("Customer")]
    public int FkCustomerId { get; set; }

    public Customer Customer { get; set; }
    public ICollection<BookLoan> BookLoans { get; set; } = [];
}