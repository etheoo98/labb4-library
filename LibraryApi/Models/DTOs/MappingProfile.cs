using AutoMapper;
using LibraryApi.Models.DbModels;
using LibraryApi.Models.DTOs.RequestDtos;

namespace LibraryApi.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Database models to DTOs
        CreateMap<Author, AuthorDto>();
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.AuthorDtos, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author)));
        CreateMap<BookAuthor, AuthorDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Author.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Author.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Author.LastName));

        CreateMap<BookLoan, BookDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Book.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Book.Description));

        CreateMap<Loan, LoanDto>()
            .ForMember(dest => dest.BookDtos, opt => opt.MapFrom(src => src.BookLoans.Select(bl => bl.Book)));
            
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.LoanDtos, opt => opt.MapFrom(src => src.Loans)); 
        
        // Map DTO to Database model
        CreateMap<AddCustomerDto, Customer>();
        
        CreateMap<AddLoanDto, Loan>()
            .ForMember(dest => dest.FkCustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.BookLoans, opt => opt.MapFrom(src => src.BookIds.Select(id => new BookLoan { FkBookId = id })));
    }
}