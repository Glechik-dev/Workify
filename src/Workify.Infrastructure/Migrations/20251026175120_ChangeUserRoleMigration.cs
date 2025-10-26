using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerRole_Role_RoleId",
                table: "JobSeekerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerRole_User_UserId",
                table: "JobSeekerRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeekerRole",
                table: "JobSeekerRole");

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

            migrationBuilder.RenameTable(
                name: "JobSeekerRole",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerRole_UserId",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekerRole_RoleId",
                table: "UserRole",
                newName: "IX_UserRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2a686a95-9aa5-4996-bd8e-86aba0e2ab7d"), "Employer" },
                    { new Guid("529149c1-58ac-4fc7-9325-6309e2100dd0"), "JobSeeker" },
                    { new Guid("61713cdd-0863-46f9-880b-e58df84dc131"), "Admin" }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2a686a95-9aa5-4996-bd8e-86aba0e2ab7d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("529149c1-58ac-4fc7-9325-6309e2100dd0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("61713cdd-0863-46f9-880b-e58df84dc131"));

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "JobSeekerRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                table: "JobSeekerRole",
                newName: "IX_JobSeekerRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId",
                table: "JobSeekerRole",
                newName: "IX_JobSeekerRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeekerRole",
                table: "JobSeekerRole",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0bbfb741-f856-4a2a-9758-02b251d14267"), "Employer" },
                    { new Guid("b5c80f88-86c4-4e2f-92de-10ad09b6435a"), "Admin" },
                    { new Guid("cfb4f096-a6da-4da3-9503-ba0a320f74d8"), "JobSeeker" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerRole_Role_RoleId",
                table: "JobSeekerRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerRole_User_UserId",
                table: "JobSeekerRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
