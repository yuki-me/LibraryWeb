using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWebAPI.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBooks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblStudents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblIssueBook",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    StuId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    BookId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIssueBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblIssueBook_tblBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "tblBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblIssueBook_tblStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tblStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblIssueBook_tblStudents_StuId",
                        column: x => x.StuId,
                        principalTable: "tblStudents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblIssueBook_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblReturnBook",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    StuId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    BookId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReturnBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblReturnBook_tblBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "tblBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblReturnBook_tblStudents_StuId",
                        column: x => x.StuId,
                        principalTable: "tblStudents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblReturnBook_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblIssueBook_BookId",
                table: "tblIssueBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tblIssueBook_StatusId",
                table: "tblIssueBook",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblIssueBook_StuId",
                table: "tblIssueBook",
                column: "StuId");

            migrationBuilder.CreateIndex(
                name: "IX_tblIssueBook_UserId",
                table: "tblIssueBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReturnBook_BookId",
                table: "tblReturnBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReturnBook_StuId",
                table: "tblReturnBook",
                column: "StuId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReturnBook_UserId",
                table: "tblReturnBook",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblIssueBook");

            migrationBuilder.DropTable(
                name: "tblReturnBook");

            migrationBuilder.DropTable(
                name: "tblStatus");

            migrationBuilder.DropTable(
                name: "tblBooks");

            migrationBuilder.DropTable(
                name: "tblStudents");

            migrationBuilder.DropTable(
                name: "tblUsers");
        }
    }
}
