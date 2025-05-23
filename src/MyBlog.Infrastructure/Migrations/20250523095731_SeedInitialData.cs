using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedBy", "CreatedByName", "CreationDate", "Description", "ImageUrl", "IsValid", "ModBy", "ModByName", "ModDate", "Name", "ReasonOfInvalid", "SortNo", "UrlDemo", "UrlGitHub" },
                values: new object[] { new Guid("444e03e7-de71-43b0-9051-06530311c7d2"), null, null, null, "Test2", "Test3", true, null, null, null, "Test1", null, 1, "Test5", "Test4" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedBy", "CreatedByName", "CreationDate", "Description", "ImageUrl", "IsValid", "ModBy", "ModByName", "ModDate", "Name", "ReasonOfInvalid", "SortNo", "UrlDemo", "UrlGitHub" },
                values: new object[] { new Guid("d2a948bb-49c4-40a1-8897-ec8c4ba0bd78"), null, null, null, "Test2", "Test3", true, null, null, null, "Test1", null, 1, "Test5", "Test4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("444e03e7-de71-43b0-9051-06530311c7d2"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("d2a948bb-49c4-40a1-8897-ec8c4ba0bd78"));
        }
    }
}
