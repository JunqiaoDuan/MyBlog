using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortNo = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ReasonOfInvalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlGitHub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlDemo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortNo = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ReasonOfInvalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ReasonOfInvalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Statistic");
        }
    }
}
