﻿// <auto-generated />
using System;
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("LibraryApi.Models.DbModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Joseph",
                            LastName = "Conrad"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ken",
                            LastName = "Kesey"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jean",
                            LastName = "Baudrillard"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "George",
                            LastName = "Orwell"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "J. D.",
                            LastName = "Salinger"
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "\"Heart of Darkness\" follows Charles Marlow as he journeys into the Congo, confronting the darkness within himself and human nature while searching for the mysterious Kurtz, who embodies the extremes of European imperialism. Through Marlow's voyage, Joseph Conrad explores the depths of human depravity and the blurred line between civilization and savagery.",
                            Title = "Heart of Darkness"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In \"One Flew Over the Cuckoo's Nest,\" Randle McMurphy's arrival at a mental institution challenges the tyrannical Nurse Ratched's authority, inspiring fellow patients to reclaim their autonomy and individuality, ultimately leading to tragic consequences in their struggle against institutional oppression.",
                            Title = "One Flew Over the Cuckoo's Nest"
                        },
                        new
                        {
                            Id = 3,
                            Description = "\"Simulacra and Simulation\" delves into Jean Baudrillard's examination of hyperreality, where simulations and representations of reality become more significant than reality itself, questioning the authenticity of modern culture and the pervasive influence of media and technology on perception and meaning.",
                            Title = "Simulacra and Simulation"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Set in a dystopian future, \"1984\" follows Winston Smith's rebellion against the totalitarian regime of Big Brother, as he seeks truth and freedom in a society where surveillance, propaganda, and thought control suppress individuality and perpetuate a perpetual state of fear and oppression.",
                            Title = "1984"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Narrated by disillusioned teenager Holden Caulfield, \"The Catcher in the Rye\" recounts his aimless journey through New York City after being expelled from prep school, as he grapples with the phoniness of adult society and yearns for genuine connections amidst his feelings of alienation and existential angst.",
                            Title = "The Catcher in the Rye"
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkAuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkBookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FkAuthorId");

                    b.HasIndex("FkBookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkAuthorId = 1,
                            FkBookId = 1
                        },
                        new
                        {
                            Id = 2,
                            FkAuthorId = 2,
                            FkBookId = 2
                        },
                        new
                        {
                            Id = 3,
                            FkAuthorId = 3,
                            FkBookId = 3
                        },
                        new
                        {
                            Id = 4,
                            FkAuthorId = 4,
                            FkBookId = 4
                        },
                        new
                        {
                            Id = 5,
                            FkAuthorId = 5,
                            FkBookId = 5
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.BookLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkBookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkLoanId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FkBookId");

                    b.HasIndex("FkLoanId");

                    b.ToTable("BookLoans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkBookId = 1,
                            FkLoanId = 1
                        },
                        new
                        {
                            Id = 2,
                            FkBookId = 2,
                            FkLoanId = 1
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Mickey",
                            LastName = "Mouse"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Minnie",
                            LastName = "Mouse"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Donald",
                            LastName = "Duck"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Daisy",
                            LastName = "Duck"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Goofy",
                            LastName = "Goof"
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FkCustomerId");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkCustomerId = 1,
                            LoanDate = new DateTime(2024, 5, 14, 7, 54, 27, 50, DateTimeKind.Local).AddTicks(749)
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.BookAuthor", b =>
                {
                    b.HasOne("LibraryApi.Models.DbModels.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("FkAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApi.Models.DbModels.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("FkBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.BookLoan", b =>
                {
                    b.HasOne("LibraryApi.Models.DbModels.Book", "Book")
                        .WithMany("BookLoans")
                        .HasForeignKey("FkBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApi.Models.DbModels.Loan", "Loan")
                        .WithMany("BookLoans")
                        .HasForeignKey("FkLoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Loan", b =>
                {
                    b.HasOne("LibraryApi.Models.DbModels.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("FkCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookLoans");
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Customer", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("LibraryApi.Models.DbModels.Loan", b =>
                {
                    b.Navigation("BookLoans");
                });
#pragma warning restore 612, 618
        }
    }
}