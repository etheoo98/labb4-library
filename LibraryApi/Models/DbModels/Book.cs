using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.DbModels;

public class Book
{
    public int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string Title { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string Description { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = [];
    public ICollection<BookLoan> BookLoans { get; set; } = [];
}