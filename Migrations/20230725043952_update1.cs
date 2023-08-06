using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                schema: "Data",
                table: "Tags",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                schema: "Data",
                table: "Post",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileId1",
                schema: "Data",
                table: "Post",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Data",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CategoryCode",
                schema: "Data",
                table: "Tags",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Post_FileId1",
                schema: "Data",
                table: "Post",
                column: "FileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Files_FileId1",
                schema: "Data",
                table: "Post",
                column: "FileId1",
                principalSchema: "Data",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Categories_CategoryCode",
                schema: "Data",
                table: "Tags",
                column: "CategoryCode",
                principalSchema: "Data",
                principalTable: "Categories",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Files_FileId1",
                schema: "Data",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Categories_CategoryCode",
                schema: "Data",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CategoryCode",
                schema: "Data",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Post_FileId1",
                schema: "Data",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                schema: "Data",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "Data",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "FileId1",
                schema: "Data",
                table: "Post");
        }
    }
}
