using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post",
                newSchema: "Data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                schema: "Data",
                table: "Post",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                schema: "Data",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "Data",
                newName: "Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");
        }
    }
}
