using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_User_UserId",
                table: "Token");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_User_UserId",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

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

            migrationBuilder.RenameTable(
                name: "UserSettings",
                newName: "JobSeekerSettings");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "JobSeekerRole");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "JobSeeker");

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
                table: "JobSeekerSettings",
                newName: "JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSettings_UserId",
                table: "JobSeekerSettings",
                newName: "IX_JobSeekerSettings_JobSeekerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "JobSeekerRole",
                newName: "JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                table: "JobSeekerRole",
                newName: "IX_JobSeekerRole_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId",
                table: "JobSeekerRole",
                newName: "IX_JobSeekerRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeekerSettings",
                table: "JobSeekerSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeekerRole",
                table: "JobSeekerRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeeker",
                table: "JobSeeker",
                column: "Id");

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
                name: "FK_JobSeekerRole_Role_RoleId",
                table: "JobSeekerRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerSettings_JobSeeker_JobSeekerId",
                table: "JobSeekerSettings",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerRole_JobSeeker_JobSeekerId",
                table: "JobSeekerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerRole_Role_RoleId",
                table: "JobSeekerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerSettings_JobSeeker_JobSeekerId",
                table: "JobSeekerSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_JobSeeker_JobSeekerId",
                table: "Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeekerSettings",
                table: "JobSeekerSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeekerRole",
                table: "JobSeekerRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeeker",
                table: "JobSeeker");

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

            migrationBuilder.RenameTable(
                name: "JobSeekerSettings",
                newName: "UserSettings");

            migrationBuilder.RenameTable(
                name: "JobSeekerRole",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "JobSeeker",
                newName: "User");

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
                table: "UserSettings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerSettings_JobSeekerId",
                table: "UserSettings",
                newName: "IX_UserSettings_UserId");

            migrationBuilder.RenameColumn(
                name: "JobSeekerId",
                table: "UserRole",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerRole_RoleId",
                table: "UserRole",
                newName: "IX_UserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerRole_JobSeekerId",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("22ab44b5-e0b7-4583-8210-879c7aa98a57"), "Employer" },
                    { new Guid("8f9092d5-e4cb-41a2-8429-338039573aad"), "Admin" },
                    { new Guid("9a73f894-ba5c-4235-b5fa-5cb6cc71371a"), "JoobSeeker" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Token_User_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_User_UserId",
                table: "UserSettings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
