using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models.DbModels;

public class BookAuthor
{
    public int Id { get; set; }
    
    [ForeignKey("Author")]
    public int FkAuthorId { get; set; }
    
    [ForeignKey("Book")]
    public int FkBookId { get; set; }
    
    public Author Author { get; set; }
    public Book Book { get; set; }
}