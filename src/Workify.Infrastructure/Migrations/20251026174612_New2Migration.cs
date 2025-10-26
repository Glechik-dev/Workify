using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class New2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerRole_JobSeeker_JobSeekerId",
                table: "JobSeekerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_JobSeeker_JobSeekerId",
                table: "Token");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0f702f2f-127f-44c3-9744-256734a3fd2a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bf0139d0-1960-47b6-9145-69fc1df7400e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e2e6a46f-5a57-4f49-9c70-32606183d80a"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "JobSeeker");

            migrationBuilder.RenameColumn(
                name: "JobSeekerId",
                table: "Token",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Token_JobSeekerId",
                table: "Token",
                newName: "IX_Token_UserId");

            migrationBuilder.RenameColumn(
                name: "JobSeekerId",
                table: "JobSeekerRole",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerRole_JobSeekerId",
                table: "JobSeekerRole",
                newName: "IX_JobSeekerRole_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "JobSeeker",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0bbfb741-f856-4a2a-9758-02b251d14267"), "Employer" },
                    { new Guid("b5c80f88-86c4-4e2f-92de-10ad09b6435a"), "Admin" },
                    { new Guid("cfb4f096-a6da-4da3-9503-ba0a320f74d8"), "JobSeeker" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeeker_UserId",
                table: "JobSeeker",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employer_UserId",
                table: "Employer",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeeker_User_UserId",
                table: "JobSeeker",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerRole_User_UserId",
                table: "JobSeekerRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Token_User_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeeker_User_UserId",
                table: "JobSeeker");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerRole_User_UserId",
                table: "JobSeekerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_User_UserId",
                table: "Token");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_JobSeeker_UserId",
                table: "JobSeeker");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0bbfb741-f856-4a2a-9758-02b251d14267"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b5c80f88-86c4-4e2f-92de-10ad09b6435a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cfb4f096-a6da-4da3-9503-ba0a320f74d8"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JobSeeker");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Token",
                newName: "JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_Token_UserId",
                table: "Token",
                newName: "IX_Token_JobSeekerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "JobSeekerRole",
                newName: "JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerRole_UserId",
                table: "JobSeekerRole",
                newName: "IX_JobSeekerRole_JobSeekerId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "JobSeeker",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "JobSeeker",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "JobSeeker",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "JobSeeker",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "JobSeeker",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0f702f2f-127f-44c3-9744-256734a3fd2a"), "Employer" },
                    { new Guid("bf0139d0-1960-47b6-9145-69fc1df7400e"), "JobSeeker" },
                    { new Guid("e2e6a46f-5a57-4f49-9c70-32606183d80a"), "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerRole_JobSeeker_JobSeekerId",
                table: "JobSeekerRole",
                column: "JobSeekerId",
                principalTable: "JobSeeker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Token_JobSeeker_JobSeekerId",
                table: "Token",
                column: "JobSeekerId",
                principalTable: "JobSeeker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
