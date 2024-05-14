using LibraryApi.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Loan> Loans { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddSampleData(modelBuilder);
    }

    private static void AddSampleData(ModelBuilder modelBuilder)
    {
        var author1 = new Author { Id = 1, FirstName = "Joseph", LastName = "Conrad" };
        var author2 = new Author { Id = 2, FirstName = "Ken", LastName = "Kesey" };
        var author3 = new Author { Id = 3, FirstName = "Jean", LastName = "Baudrillard" };
        var author4 = new Author { Id = 4, FirstName = "George", LastName = "Orwell" };
        var author5 = new Author { Id = 5, FirstName = "J. D.", LastName = "Salinger" };
    
        var book1 = new Book { Id = 1, Title = "Heart of Darkness", Description = "\"Heart of Darkness\" follows Charles Marlow as he journeys into the Congo, confronting the darkness within himself and human nature while searching for the mysterious Kurtz, who embodies the extremes of European imperialism. Through Marlow's voyage, Joseph Conrad explores the depths of human depravity and the blurred line between civilization and savagery." };
        var book2 = new Book { Id = 2, Title = "One Flew Over the Cuckoo's Nest", Description = "In \"One Flew Over the Cuckoo's Nest,\" Randle McMurphy's arrival at a mental institution challenges the tyrannical Nurse Ratched's authority, inspiring fellow patients to reclaim their autonomy and individuality, ultimately leading to tragic consequences in their struggle against institutional oppression." };
        var book3 = new Book { Id = 3, Title = "Simulacra and Simulation", Description = "\"Simulacra and Simulation\" delves into Jean Baudrillard's examination of hyperreality, where simulations and representations of reality become more significant than reality itself, questioning the authenticity of modern culture and the pervasive influence of media and technology on perception and meaning." };
        var book4 = new Book { Id = 4, Title = "1984", Description = "Set in a dystopian future, \"1984\" follows Winston Smith's rebellion against the totalitarian regime of Big Brother, as he seeks truth and freedom in a society where surveillance, propaganda, and thought control suppress individuality and perpetuate a perpetual state of fear and oppression." };
        var book5 = new Book { Id = 5, Title = "The Catcher in the Rye", Description = "Narrated by disillusioned teenager Holden Caulfield, \"The Catcher in the Rye\" recounts his aimless journey through New York City after being expelled from prep school, as he grapples with the phoniness of adult society and yearns for genuine connections amidst his feelings of alienation and existential angst." };
    
        var bookAuthor1 = new BookAuthor { Id = 1, FkAuthorId = author1.Id, FkBookId = book1.Id };
        var bookAuthor2 = new BookAuthor { Id = 2, FkAuthorId = author2.Id, FkBookId = book2.Id };
        var bookAuthor3 = new BookAuthor { Id = 3, FkAuthorId = author3.Id, FkBookId = book3.Id };
        var bookAuthor4 = new BookAuthor { Id = 4, FkAuthorId = author4.Id, FkBookId = book4.Id };
        var bookAuthor5 = new BookAuthor { Id = 5, FkAuthorId = author5.Id, FkBookId = book5.Id };
    
        var customer1 = new Customer { Id = 1, FirstName = "Mickey", LastName = "Mouse" };
        var customer2 = new Customer { Id = 2, FirstName = "Minnie", LastName = "Mouse" };
        var customer3 = new Customer { Id = 3, FirstName = "Donald", LastName = "Duck" };
        var customer4 = new Customer { Id = 4, FirstName = "Daisy", LastName = "Duck" };
        var customer5 = new Customer { Id = 5, FirstName = "Goofy", LastName = "Goof" };

        var loan1 = new Loan { Id = 1, FkCustomerId = customer1.Id, LoanDate = DateTime.Now };
    
        var bookLoan1 = new BookLoan { Id = 1, FkLoanId = loan1.Id, FkBookId = book1.Id };
        var bookLoan2 = new BookLoan { Id = 2, FkLoanId = loan1.Id, FkBookId = book2.Id };

        modelBuilder.Entity<Author>().HasData(author1, author2, author3, author4, author5);
        modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5);
        modelBuilder.Entity<BookAuthor>().HasData(bookAuthor1, bookAuthor2, bookAuthor3, bookAuthor4, bookAuthor5);
        modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3, customer4, customer5);
        modelBuilder.Entity<Loan>().HasData(loan1);
        modelBuilder.Entity<BookLoan>().HasData(bookLoan1, bookLoan2);
    }
}