using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParentIdAndRepliedIdColumnsToCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RepliedId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RepliedId",
                table: "Comments");
        }
    }
}
