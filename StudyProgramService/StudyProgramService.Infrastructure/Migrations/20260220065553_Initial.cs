using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyProgramService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title_Value = table.Column<string>(type: "text", nullable: false),
                    Description_Value = table.Column<string>(type: "text", nullable: false),
                    DailyStudyTarget_Value = table.Column<int>(type: "integer", nullable: false),
                    DaysPerWeek_Value = table.Column<int>(type: "integer", nullable: false),
                    DurationInWeeks_Value = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Price_Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Price_Currency_Value = table.Column<string>(type: "text", nullable: false),
                    EnrollmentStrategy_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPrograms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyPrograms");
        }
    }
}
