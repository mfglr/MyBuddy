using System.Collections.Generic;
using Media.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaProcessingContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Metadata",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ModerationResult",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Thumbnails",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "Transcodings",
                table: "Media",
                newName: "Context");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Media",
                newName: "Transcodings");

            migrationBuilder.AddColumn<MediaInstruction>(
                name: "Instruction",
                table: "Media",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<Metadata>(
                name: "Metadata",
                table: "Media",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<ModerationResult>(
                name: "ModerationResult",
                table: "Media",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<IReadOnlyList<Thumbnail>>(
                name: "Thumbnails",
                table: "Media",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Media",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Media",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
