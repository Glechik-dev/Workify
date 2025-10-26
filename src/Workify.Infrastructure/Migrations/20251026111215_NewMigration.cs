using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("22ab44b5-e0b7-4583-8210-879c7aa98a57"), "Employer" },
                    { new Guid("8f9092d5-e4cb-41a2-8429-338039573aad"), "Admin" },
                    { new Guid("9a73f894-ba5c-4235-b5fa-5cb6cc71371a"), "JoobSeeker" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("22ab44b5-e0b7-4583-8210-879c7aa98a57"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8f9092d5-e4cb-41a2-8429-338039573aad"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9a73f894-ba5c-4235-b5fa-5cb6cc71371a"));

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
    }
}
