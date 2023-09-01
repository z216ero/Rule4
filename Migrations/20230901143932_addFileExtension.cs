using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class addFileExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                schema: "Data",
                table: "Post",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                schema: "Data",
                table: "Post");
        }
    }
}
