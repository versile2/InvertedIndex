using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 3,
                columns: new[] { "Href", "Icon", "OrderById", "ParentId", "Title" },
                values: new object[] { null, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M19 7v4H5.83l3.58-3.59L8 6l-6 6 6 6 1.41-1.41L5.83 13H21V7z\"/>", 99, null, "Return to GitHub" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 4,
                columns: new[] { "Href", "Icon", "IsNewWindow", "OrderById", "ParentId", "Title" },
                values: new object[] { "https://github.com/karan/Projects", null, true, 0, 3, "Mega Project List" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 5,
                columns: new[] { "Href", "OrderById", "ParentId", "Title" },
                values: new object[] { "https://github.com/karan/Projects-Solutions", 1, 3, "Mega Solution List" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 6,
                columns: new[] { "Href", "Icon", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[] { null, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><g><path d=\"M17,11c0.34,0,0.67,0.04,1,0.09V6.27L10.5,3L3,6.27v4.91c0,4.54,3.2,8.79,7.5,9.82c0.55-0.13,1.08-0.32,1.6-0.55 C11.41,19.47,11,18.28,11,17C11,13.69,13.69,11,17,11z\"/><path d=\"M17,13c-2.21,0-4,1.79-4,4c0,2.21,1.79,4,4,4s4-1.79,4-4C21,14.79,19.21,13,17,13z M17,14.38c0.62,0,1.12,0.51,1.12,1.12 s-0.51,1.12-1.12,1.12s-1.12-0.51-1.12-1.12S16.38,14.38,17,14.38z M17,19.75c-0.93,0-1.74-0.46-2.24-1.17 c0.05-0.72,1.51-1.08,2.24-1.08s2.19,0.36,2.24,1.08C18.74,19.29,17.93,19.75,17,19.75z\"/></g></g>", false, 98, null, "adminrole", "Admin" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 7,
                columns: new[] { "Href", "Icon", "OrderById", "ParentId", "Title" },
                values: new object[] { "managenav", null, 0, 6, "Navigation" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 8,
                columns: new[] { "Href", "ParentId", "Role", "Title" },
                values: new object[] { "docupload", 2, null, "Upload Documents" });

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

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 3,
                columns: new[] { "Href", "Icon", "OrderById", "ParentId", "Title" },
                values: new object[] { "docupload", null, 0, 2, "Upload Documents" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 4,
                columns: new[] { "Href", "Icon", "IsNewWindow", "OrderById", "ParentId", "Title" },
                values: new object[] { null, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M19 7v4H5.83l3.58-3.59L8 6l-6 6 6 6 1.41-1.41L5.83 13H21V7z\"/>", false, 99, null, "Return to GitHub" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 5,
                columns: new[] { "Href", "OrderById", "ParentId", "Title" },
                values: new object[] { "https://github.com/karan/Projects", 0, 4, "Mega Project List" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 6,
                columns: new[] { "Href", "Icon", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[] { "https://github.com/karan/Projects-Solutions", null, true, 1, 4, null, "Mega Solution List" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 7,
                columns: new[] { "Href", "Icon", "OrderById", "ParentId", "Title" },
                values: new object[] { null, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><g><path d=\"M17,11c0.34,0,0.67,0.04,1,0.09V6.27L10.5,3L3,6.27v4.91c0,4.54,3.2,8.79,7.5,9.82c0.55-0.13,1.08-0.32,1.6-0.55 C11.41,19.47,11,18.28,11,17C11,13.69,13.69,11,17,11z\"/><path d=\"M17,13c-2.21,0-4,1.79-4,4c0,2.21,1.79,4,4,4s4-1.79,4-4C21,14.79,19.21,13,17,13z M17,14.38c0.62,0,1.12,0.51,1.12,1.12 s-0.51,1.12-1.12,1.12s-1.12-0.51-1.12-1.12S16.38,14.38,17,14.38z M17,19.75c-0.93,0-1.74-0.46-2.24-1.17 c0.05-0.72,1.51-1.08,2.24-1.08s2.19,0.36,2.24,1.08C18.74,19.29,17.93,19.75,17,19.75z\"/></g></g>", 98, null, "Admin" });

            migrationBuilder.UpdateData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 8,
                columns: new[] { "Href", "ParentId", "Role", "Title" },
                values: new object[] { "managenav", 7, "adminrole", "Navigation" });

            migrationBuilder.InsertData(
                table: "Data_NavLinks",
                columns: new[] { "NavLinkId", "Href", "Icon", "IsActive", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[,]
                {
                    { 32, null, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M2 17h2v.5H3v1h1v.5H2v1h3v-4H2v1zm1-9h1V4H2v1h1v3zm-1 3h1.8L2 13.1v.9h3v-1H3.2L5 10.9V10H2v1zm5-6v2h14V5H7zm0 14h14v-2H7v2zm0-6h14v-2H7v2z\"/>", true, false, 97, null, null, "Hierarchy Nav" },
                    { 33, null, null, true, false, 1, 32, null, "Level 1" },
                    { 34, null, null, true, false, 2, 33, null, "Level 2" },
                    { 35, null, null, true, false, 3, 34, null, "Level 3" },
                    { 36, null, null, true, false, 4, 35, null, "Level 4" },
                    { 37, null, null, true, false, 5, 36, null, "Level 5" },
                    { 38, null, null, true, false, 6, 37, null, "Level 6" },
                    { 39, null, null, true, false, 7, 38, null, "Level 7" },
                    { 40, null, null, true, false, 8, 39, null, "Level 8" },
                    { 41, null, null, true, false, 9, 40, null, "Level 9" }
                });
        }
    }
}
