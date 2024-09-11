using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DocumentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.Sql("ALTER TABLE Documents ADD COLUMN Data BLOB");

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 4,
                column: "Title",
                value: "Return to GitHub");

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 5,
                column: "Title",
                value: "Mega Project List");

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 6,
                column: "Title",
                value: "Mega Solution List");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 4,
                column: "Title",
                value: "Return to GitHub Projects");

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 5,
                column: "Title",
                value: "Projects");

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 6,
                column: "Title",
                value: "Solutions");
        }
    }
}
