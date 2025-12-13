using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetParentIdColumnAsIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentId",
                table: "Comments");
        }
    }
}
