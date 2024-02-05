using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessTier.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contactname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContacttypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contact_types_ContacttypeId",
                        column: x => x.ContacttypeId,
                        principalTable: "types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contactname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContacttypeId = table.Column<int>(type: "int", nullable: true),
                    Phonenumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "needed according to pictures"),
                    DateBooking = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "needed according to pictures"),
                    Favorite = table.Column<bool>(type: "bit", nullable: false, comment: "needed according to pictures"),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservation_contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservation_types_ContacttypeId",
                        column: x => x.ContacttypeId,
                        principalTable: "types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contact_ContacttypeId",
                table: "contact",
                column: "ContacttypeId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_ContactId",
                table: "reservation",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_ContacttypeId",
                table: "reservation",
                column: "ContacttypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "types");
        }
    }
}
