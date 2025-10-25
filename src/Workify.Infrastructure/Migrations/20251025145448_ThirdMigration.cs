using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0bd8d139-3847-4cd4-b6f3-35df6da5971a"), "JoobSeeker" },
                    { new Guid("59691be7-f9f7-497a-b8ef-2b7124ecbcd2"), "Admin" },
                    { new Guid("d2f1a3c6-95da-421a-9c87-d59d41ac353e"), "Employer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0bd8d139-3847-4cd4-b6f3-35df6da5971a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("59691be7-f9f7-497a-b8ef-2b7124ecbcd2"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d2f1a3c6-95da-421a-9c87-d59d41ac353e"));
        }
    }
}
