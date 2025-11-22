using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationWithResumeAndCavacnies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobSeekerSettings");

            migrationBuilder.CreateTable(
                name: "EmployerSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerSettings_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_JobSeeker_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancy_Employer_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployerDislikedResume",
                columns: table => new
                {
                    DislikedResumeId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhoDislikesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerDislikedResume", x => new { x.DislikedResumeId, x.WhoDislikesId });
                    table.ForeignKey(
                        name: "FK_EmployerDislikedResume_Employer_WhoDislikesId",
                        column: x => x.WhoDislikesId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployerDislikedResume_Resume_DislikedResumeId",
                        column: x => x.DislikedResumeId,
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployerLikedResume",
                columns: table => new
                {
                    LikedResumeId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhoLikesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerLikedResume", x => new { x.LikedResumeId, x.WhoLikesId });
                    table.ForeignKey(
                        name: "FK_EmployerLikedResume_Employer_WhoLikesId",
                        column: x => x.WhoLikesId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployerLikedResume_Resume_LikedResumeId",
                        column: x => x.LikedResumeId,
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerDislikedVacancies",
                columns: table => new
                {
                    DislikedVacancyId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhoDislikesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerDislikedVacancies", x => new { x.DislikedVacancyId, x.WhoDislikesId });
                    table.ForeignKey(
                        name: "FK_JobSeekerDislikedVacancies_JobSeeker_WhoDislikesId",
                        column: x => x.WhoDislikesId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerDislikedVacancies_Vacancy_DislikedVacancyId",
                        column: x => x.DislikedVacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerLikedVacancies",
                columns: table => new
                {
                    LikedVacancyId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhoLikesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerLikedVacancies", x => new { x.LikedVacancyId, x.WhoLikesId });
                    table.ForeignKey(
                        name: "FK_JobSeekerLikedVacancies_JobSeeker_WhoLikesId",
                        column: x => x.WhoLikesId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerLikedVacancies_Vacancy_LikedVacancyId",
                        column: x => x.LikedVacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1e3a2ff0-a8cd-4bf1-b6d8-0de5d6afbe31"), "Employer" },
                    { new Guid("6e268631-8fa9-4978-a551-65a476c14e1a"), "JobSeeker" },
                    { new Guid("a550aef8-76cd-49d7-992d-44426687bb82"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployerDislikedResume_WhoDislikesId",
                table: "EmployerDislikedResume",
                column: "WhoDislikesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerLikedResume_WhoLikesId",
                table: "EmployerLikedResume",
                column: "WhoLikesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerSettings_EmployerId",
                table: "EmployerSettings",
                column: "EmployerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerDislikedVacancies_WhoDislikesId",
                table: "JobSeekerDislikedVacancies",
                column: "WhoDislikesId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerLikedVacancies_WhoLikesId",
                table: "JobSeekerLikedVacancies",
                column: "WhoLikesId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_AuthorId",
                table: "Resume",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_AuthorId",
                table: "Vacancy",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerDislikedResume");

            migrationBuilder.DropTable(
                name: "EmployerLikedResume");

            migrationBuilder.DropTable(
                name: "EmployerSettings");

            migrationBuilder.DropTable(
                name: "JobSeekerDislikedVacancies");

            migrationBuilder.DropTable(
                name: "JobSeekerLikedVacancies");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "Vacancy");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1e3a2ff0-a8cd-4bf1-b6d8-0de5d6afbe31"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6e268631-8fa9-4978-a551-65a476c14e1a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a550aef8-76cd-49d7-992d-44426687bb82"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobSeekerSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2a686a95-9aa5-4996-bd8e-86aba0e2ab7d"), "Employer" },
                    { new Guid("529149c1-58ac-4fc7-9325-6309e2100dd0"), "JobSeeker" },
                    { new Guid("61713cdd-0863-46f9-880b-e58df84dc131"), "Admin" }
                });
        }
    }
}
