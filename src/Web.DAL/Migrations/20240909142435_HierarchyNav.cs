using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HierarchyNav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Data_NavLinks",
                columns: new[] { "NavLinkId", "Href", "Icon", "IsActive", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[,]
                {
                    { 12, null, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M2 17h2v.5H3v1h1v.5H2v1h3v-4H2v1zm1-9h1V4H2v1h1v3zm-1 3h1.8L2 13.1v.9h3v-1H3.2L5 10.9V10H2v1zm5-6v2h14V5H7zm0 14h14v-2H7v2zm0-6h14v-2H7v2z\"/>", true, false, 97, null, null, "Hierarchy Nav" },
                    { 13, null, null, true, false, 1, 12, null, "Level 1" },
                    { 14, null, null, true, false, 2, 13, null, "Level 2" },
                    { 15, null, null, true, false, 3, 14, null, "Level 3" },
                    { 16, null, null, true, false, 4, 15, null, "Level 4" },
                    { 17, null, null, true, false, 5, 16, null, "Level 5" },
                    { 18, null, null, true, false, 6, 17, null, "Level 6" },
                    { 19, null, null, true, false, 7, 18, null, "Level 7" },
                    { 20, null, null, true, false, 8, 19, null, "Level 8" },
                    { 21, null, null, true, false, 9, 20, null, "Level 9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 12);
        }
    }
}
