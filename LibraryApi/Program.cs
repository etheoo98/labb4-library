using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Models.DbModels;
using LibraryApi.Models.DTOs;
using LibraryApi.Models.DTOs.RequestDtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

const string apiPrefix = "/api/v1";

//
// Retrieves all Customers
//
app.MapGet($"{apiPrefix}/customers", async (ApplicationDbContext context, IMapper mapper) =>
{
    var customers = await context.Customers
        .Include(c => c.Loans)
        .ThenInclude(l => l.BookLoans)
        .ThenInclude(bl => bl.Book)
        .ThenInclude(b => b.BookAuthors)
        .ThenInclude(ba => ba.Author)
        .ToListAsync();
    
    var customerDtos = mapper.Map<List<CustomerDto>>(customers);

    return customerDtos.Count == 0 ? Results.NoContent() : Results.Ok(customerDtos);
});

//
// Retrieves all Loans
//
app.MapGet($"{apiPrefix}/loans", async (ApplicationDbContext context, IMapper mapper) =>
{
    var loans = await context.Loans
        .Include(l => l.Customer)
        .Include(l => l.BookLoans)
        .ThenInclude(bl => bl.Book)
        .ThenInclude(b => b.BookAuthors)
        .ThenInclude(ba => ba.Author)
        .ToListAsync();
    
    var loanDtos = mapper.Map<List<LoanDto>>(loans);

    return loanDtos.Count == 0 ? Results.NoContent() : Results.Ok(loanDtos);
});

//
// Retrieves all Books
//
app.MapGet($"{apiPrefix}/books", async (ApplicationDbContext context, IMapper mapper) =>
{
    var books = await context.Books
        .Include(b => b.BookAuthors)
        .ThenInclude(ba => ba.Author)
        .ToListAsync();
    
    var bookDtos = mapper.Map<List<BookDto>>(books);

    return bookDtos.Count == 0 ? Results.NoContent() : Results.Ok(bookDtos);
});

//
// Retrieves a specific Customer
//
app.MapGet($"{apiPrefix}/customers/{{id:int}}", async (int id, ApplicationDbContext context, IMapper mapper) =>
{
    var customer = await context.Customers
        .Where(c => c.Id == id)
        .Include(c => c.Loans)
        .ThenInclude(l => l.BookLoans)
        .ThenInclude(bl => bl.Book)
        .ThenInclude(b => b.BookAuthors)
        .ThenInclude(ba => ba.Author)
        .FirstOrDefaultAsync();
    
    var customerDto = mapper.Map<CustomerDto>(customer);

    return customerDto == null ? Results.NoContent() : Results.Ok(customerDto);
});

//
// Retrieves a specific Customer's Loans
//
app.MapGet($"{apiPrefix}/customers/{{id:int}}/loans", async (int id, ApplicationDbContext context, IMapper mapper) =>
{
    var loans = await context.Loans
        .Where(l => l.Customer.Id == id)
        .Include(l => l.Customer)
        .Include(l => l.BookLoans)
        .ThenInclude(bl => bl.Book)
        .ThenInclude(b => b.BookAuthors)
        .ThenInclude(ba => ba.Author)
        .ToListAsync();
    
    var loanDtos = mapper.Map<List<LoanDto>>(loans);

    return loanDtos == null ? Results.NoContent() : Results.Ok(loanDtos);
});

//
// Create a new Customer
//
app.MapPost($"{apiPrefix}/customers", async (AddCustomerDto dto, ApplicationDbContext context, IMapper mapper) =>
{
    var customer = mapper.Map<Customer>(dto);

    await context.Customers.AddAsync(customer);
    await context.SaveChangesAsync();

    var customerDto = mapper.Map<CustomerDto>(customer);

    return Results.Created($"{apiPrefix}/customers/{customerDto.Id}", customerDto);
});

//
// Create a new Loan for a Customer
//
app.MapPost($"{apiPrefix}/customers/loans", async (AddLoanDto dto, ApplicationDbContext context, IMapper mapper) =>
{
    var customer = await context.Customers.FindAsync(dto.CustomerId);
    
    if (customer == null) return Results.NotFound();

    var books = await context.Books.Where(b => dto.BookIds.Contains(b.Id)).ToListAsync();

    if (books.Count != dto.BookIds.Count) return Results.BadRequest();

    var loan = mapper.Map<Loan>(dto);

    await context.Loans.AddAsync(loan);
    await context.SaveChangesAsync();

    return Results.Created();
});

//
// Update a Customer
//
app.MapPut($"{apiPrefix}/customers/{{id:int}}", async (int id, AddCustomerDto dto, ApplicationDbContext context, IMapper mapper) =>
{
    var customer = await context.Customers.FindAsync(id);

    if (customer == null) return Results.NotFound();

    mapper.Map(dto, customer);

    await context.SaveChangesAsync();

    var customerDto = mapper.Map<CustomerDto>(customer);

    return Results.Ok(customerDto);
});

//
// Delete a Customer
//
app.MapDelete($"{apiPrefix}/customers/{{id:int}}", async (int id, ApplicationDbContext context, IMapper mapper) =>
{
    var customer = await context.Customers.FindAsync(id);

    if (customer == null) return Results.NotFound();

    context.Customers.Remove(customer);
    await context.SaveChangesAsync();

    return Results.NoContent();
});

//
// Return a Loan
//
app.MapPut($"{apiPrefix}/loans/{{id:int}}/return", async (int id, ApplicationDbContext context) =>
{
    var loan = await context.Loans.FindAsync(id);

    if (loan == null) return Results.NotFound();
    
    loan.ReturnDate = DateTime.UtcNow;
    
    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();