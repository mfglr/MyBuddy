using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StudyProgramInviteService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyProgramInvites",
                columns: table => new
                {
                    StudyProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    StudyProgramOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgramInvites", x => new { x.StudyProgramId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "StudyProgramInviteStates",
                columns: table => new
                {
                    SPIStudyProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    SPIUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StateValue = table.Column<int>(type: "integer", nullable: false),
                    InvalidationReason = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgramInviteStates", x => new { x.SPIStudyProgramId, x.SPIUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_StudyProgramInviteStates_StudyProgramInvites_SPIStudyProgra~",
                        columns: x => new { x.SPIStudyProgramId, x.SPIUserId },
                        principalTable: "StudyProgramInvites",
                        principalColumns: new[] { "StudyProgramId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyProgramInviteStates");

            migrationBuilder.DropTable(
                name: "StudyProgramInvites");
        }
    }
}
