using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models.DbModels;

public class BookLoan
{
    public int Id { get; set; }
    
    [ForeignKey("Loan")]
    public int FkLoanId { get; set; }
    
    [ForeignKey("Book")]
    public int FkBookId { get; set; }
    
    public Loan Loan { get; set; }
    public Book Book { get; set; }
}