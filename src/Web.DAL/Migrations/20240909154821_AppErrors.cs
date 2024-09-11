using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AppErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ErrorStatus",
                columns: table => new
                {
                    ErrorStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ErrorStatusText = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorStatus", x => x.ErrorStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AppErrors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LoggedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 99, nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    ErrorStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppErrors", x => x.ErrorId);
                    table.ForeignKey(
                        name: "FK_AppErrors_ErrorStatus_ErrorStatusId",
                        column: x => x.ErrorStatusId,
                        principalTable: "ErrorStatus",
                        principalColumn: "ErrorStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Data_NavLinks",
                columns: new[] { "NavLinkId", "Href", "Icon", "IsActive", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[,]
                {
                    { 11, "viewerror", null, true, false, 1, 7, null, "View Error Log" },
                    { 32, null, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M2 17h2v.5H3v1h1v.5H2v1h3v-4H2v1zm1-9h1V4H2v1h1v3zm-1 3h1.8L2 13.1v.9h3v-1H3.2L5 10.9V10H2v1zm5-6v2h14V5H7zm0 14h14v-2H7v2zm0-6h14v-2H7v2z\"/>", true, false, 97, null, null, "Hierarchy Nav" }
                });

            migrationBuilder.InsertData(
                table: "ErrorStatus",
                columns: new[] { "ErrorStatusId", "ErrorStatusText" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Acknowledged" },
                    { 3, "Resolved" }
                });

            migrationBuilder.InsertData(
                table: "Data_NavLinks",
                columns: new[] { "NavLinkId", "Href", "Icon", "IsActive", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[,]
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_AppErrors_ErrorStatusId",
                table: "AppErrors",
                column: "ErrorStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppErrors");

            migrationBuilder.DropTable(
                name: "ErrorStatus");

            migrationBuilder.DeleteData(
                table: "Data_NavLinks",
                keyColumn: "NavLinkId",
                keyValue: 11);

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
    }
}
