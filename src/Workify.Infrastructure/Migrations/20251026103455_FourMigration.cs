using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FourMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2b28d356-b123-458f-b922-9d057d621c82"), "JoobSeeker" },
                    { new Guid("93dde8e7-710c-4ed7-a6e5-4f836d14b53b"), "Employer" },
                    { new Guid("d5dfb876-7bb1-4d4d-9439-cd405d9d2ba3"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2b28d356-b123-458f-b922-9d057d621c82"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("93dde8e7-710c-4ed7-a6e5-4f836d14b53b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d5dfb876-7bb1-4d4d-9439-cd405d9d2ba3"));

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
    }
}
