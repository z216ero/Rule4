using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rule4.Migrations
{
    /// <inheritdoc />
    public partial class deleteFileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Files_FileId1",
                schema: "Data",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Post_FileId1",
                schema: "Data",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "FileId1",
                schema: "Data",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "FileId",
                schema: "Data",
                table: "Post",
                newName: "Source");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Source",
                schema: "Data",
                table: "Post",
                newName: "FileId");

            migrationBuilder.AddColumn<long>(
                name: "FileId1",
                schema: "Data",
                table: "Post",
                type: "bigint",
                nullable: true);

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
        }
    }
}
