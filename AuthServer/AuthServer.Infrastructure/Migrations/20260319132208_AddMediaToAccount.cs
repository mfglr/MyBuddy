using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<IReadOnlyList<Media.Models.MediaProcessingContext>>(
                name: "Media",
                table: "AspNetUsers",
                type: "jsonb",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Media",
                table: "AspNetUsers");
        }
    }
}
