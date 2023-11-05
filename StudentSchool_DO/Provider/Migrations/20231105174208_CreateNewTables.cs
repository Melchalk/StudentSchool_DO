using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_pages = table.Column<int>(type: "int", nullable: false),
                    Year_publishing = table.Column<int>(type: "int", nullable: false),
                    City_publishing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hall_no = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
