using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkAuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkBookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_FkAuthorId",
                        column: x => x.FkAuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_FkBookId",
                        column: x => x.FkBookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FkCustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_FkCustomerId",
                        column: x => x.FkCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkLoanId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkBookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLoans_Books_FkBookId",
                        column: x => x.FkBookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_Loans_FkLoanId",
                        column: x => x.FkLoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Joseph", "Conrad" },
                    { 2, "Ken", "Kesey" },
                    { 3, "Jean", "Baudrillard" },
                    { 4, "George", "Orwell" },
                    { 5, "J. D.", "Salinger" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "\"Heart of Darkness\" follows Charles Marlow as he journeys into the Congo, confronting the darkness within himself and human nature while searching for the mysterious Kurtz, who embodies the extremes of European imperialism. Through Marlow's voyage, Joseph Conrad explores the depths of human depravity and the blurred line between civilization and savagery.", "Heart of Darkness" },
                    { 2, "In \"One Flew Over the Cuckoo's Nest,\" Randle McMurphy's arrival at a mental institution challenges the tyrannical Nurse Ratched's authority, inspiring fellow patients to reclaim their autonomy and individuality, ultimately leading to tragic consequences in their struggle against institutional oppression.", "One Flew Over the Cuckoo's Nest" },
                    { 3, "\"Simulacra and Simulation\" delves into Jean Baudrillard's examination of hyperreality, where simulations and representations of reality become more significant than reality itself, questioning the authenticity of modern culture and the pervasive influence of media and technology on perception and meaning.", "Simulacra and Simulation" },
                    { 4, "Set in a dystopian future, \"1984\" follows Winston Smith's rebellion against the totalitarian regime of Big Brother, as he seeks truth and freedom in a society where surveillance, propaganda, and thought control suppress individuality and perpetuate a perpetual state of fear and oppression.", "1984" },
                    { 5, "Narrated by disillusioned teenager Holden Caulfield, \"The Catcher in the Rye\" recounts his aimless journey through New York City after being expelled from prep school, as he grapples with the phoniness of adult society and yearns for genuine connections amidst his feelings of alienation and existential angst.", "The Catcher in the Rye" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Mickey", "Mouse" },
                    { 2, "Minnie", "Mouse" },
                    { 3, "Donald", "Duck" },
                    { 4, "Daisy", "Duck" },
                    { 5, "Goofy", "Goof" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "Id", "FkAuthorId", "FkBookId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "FkCustomerId", "LoanDate", "ReturnDate" },
                values: new object[] { 1, 1, new DateTime(2024, 5, 14, 7, 54, 27, 50, DateTimeKind.Local).AddTicks(749), null });

            migrationBuilder.InsertData(
                table: "BookLoans",
                columns: new[] { "Id", "FkBookId", "FkLoanId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_FkAuthorId",
                table: "BookAuthors",
                column: "FkAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_FkBookId",
                table: "BookAuthors",
                column: "FkBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_FkBookId",
                table: "BookLoans",
                column: "FkBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_FkLoanId",
                table: "BookLoans",
                column: "FkLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_FkCustomerId",
                table: "Loans",
                column: "FkCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
