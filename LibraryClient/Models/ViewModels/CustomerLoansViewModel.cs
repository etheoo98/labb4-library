namespace LibraryClient.Models.ViewModels;

public class CustomerLoansViewModel
{
    public Customer Customer { get; set; }
    public List<Loan>? Loans { get; set; } = [];
}