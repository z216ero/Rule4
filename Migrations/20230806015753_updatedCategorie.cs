using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class updatedCategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Data",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Data",
                table: "Categories");
        }
    }
}
