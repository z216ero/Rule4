using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class addViewCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ViewCount",
                schema: "Data",
                table: "Post",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                schema: "Data",
                table: "Post");
        }
    }
}
