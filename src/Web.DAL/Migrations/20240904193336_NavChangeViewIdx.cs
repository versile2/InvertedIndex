using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NavChangeViewIdx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 9,
                column: "OrderById",
                value: 1);

            migrationBuilder.InsertData(
                table: "Data_NavLinks",
                columns: new[] { "NavLinkId", "Href", "Icon", "IsActive", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[] { 10, "viewidx", null, true, false, 2, 2, null, "View Index" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 9,
                column: "OrderById",
                value: 0);
        }
    }
}
