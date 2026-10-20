using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrialA.Migrations
{
    /// <inheritdoc />
    public partial class inti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "candidateProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    yearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_candidateProfiles_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Wepsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companies_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeTypr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobs_companies_companyId",
                        column: x => x.companyId,
                        principalTable: "companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CandidteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applications_candidateProfiles_CandidteId",
                        column: x => x.CandidteId,
                        principalTable: "candidateProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_applications_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@example.com", "Ahmed Hassan", "123456", "Candidate" },
                    { 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@example.com", "Sara Mohamed", "123456", "Employer" },
                    { 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@example.com", "Omer Ali", "123456", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "candidateProfiles",
                columns: new[] { "Id", "Phone", "ResumeUrl", "Skill", "UserID", "yearsOfExperience" },
                values: new object[,]
                {
                    { 1, "01012345678", "example.com/resume1", "ASP.NET CORE", 1, 3 },
                    { 2, "010987654321", "example.com/resume2", "Java", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Description", "Location", "Name", "UserID", "Wepsite" },
                values: new object[,]
                {
                    { 1, "software development", "Cairo", "Tech Solution", 1, "TechSolution.example.com" },
                    { 2, "IT consluting ", "Giza", "Futur System", 2, "https/FuturSystem.example.com" }
                });

            migrationBuilder.InsertData(
                table: "jobs",
                columns: new[] { "Id", "DeadTime", "Description", "EmployeeTypr", "Location", "PostedDate", "Salary", "Status", "Title", "companyId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop by ASP.Net", "FullTime", "Cairo", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Open", "Backend", 1 },
                    { 2, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop Wep interface", "Fulltime", "Giza", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m, "Open", "Frontend", 2 },
                    { 3, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop Wep interface", "Fulltime", "Giza", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, "Open", "back", 2 }
                });

            migrationBuilder.InsertData(
                table: "applications",
                columns: new[] { "Id", "ApplicationDate", "CandidteId", "CoverLetter", "JobId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "interested in Backend", 2, "Pending" },
                    { 2, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Experienced in Wep", 2, "UnderReview" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_applications_CandidteId",
                table: "applications",
                column: "CandidteId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_JobId",
                table: "applications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_candidateProfiles_UserID",
                table: "candidateProfiles",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_UserID",
                table: "companies",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_companyId",
                table: "jobs",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "candidateProfiles");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
