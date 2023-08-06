using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Categories_CategoryCode",
                schema: "Data",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CategoryCode",
                schema: "Data",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                schema: "Data",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Data",
                table: "Tags",
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
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                schema: "Data",
                table: "Tags",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Data",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CategoryCode",
                schema: "Data",
                table: "Tags",
                column: "CategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Categories_CategoryCode",
                schema: "Data",
                table: "Tags",
                column: "CategoryCode",
                principalSchema: "Data",
                principalTable: "Categories",
                principalColumn: "Code");
        }
    }
}
