using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_Value",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Value",
                table: "AspNetUsers");
        }
    }
}
