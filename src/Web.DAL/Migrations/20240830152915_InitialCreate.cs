using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data_NavLinks",
                columns: table => new
                {
                    NavLinkId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderById = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Href = table.Column<string>(type: "TEXT", maxLength: 299, nullable: true),
                    Role = table.Column<string>(type: "TEXT", maxLength: 299, nullable: true),
                    IsNewWindow = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data_NavLinks", x => x.NavLinkId);
                    table.ForeignKey(
                        name: "FK_Data_NavLinks_Data_NavLinks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Data_NavLinks",
                        principalColumn: "NavLinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Data_NavLinks",
                columns: new[] { "NavLinkId", "Href", "Icon", "IsActive", "IsNewWindow", "OrderById", "ParentId", "Role", "Title" },
                values: new object[,]
                {
                    { 1, " ", "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z\"/>", true, false, 0, null, null, "Home" },
                    { 2, "", "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M12 1L3 5v6c0 5.55 3.84 10.74 9 12 5.16-1.26 9-6.45 9-12V5l-9-4zm-2 16l-4-4 1.41-1.41L10 14.17l6.59-6.59L18 9l-8 8z\"/>", true, false, 1, null, null, "Inverted Index" },
                    { 4, null, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M19 7v4H5.83l3.58-3.59L8 6l-6 6 6 6 1.41-1.41L5.83 13H21V7z\"/>", true, false, 99, null, null, "Return to GitHub Projects" },
                    { 7, null, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><g><path d=\"M17,11c0.34,0,0.67,0.04,1,0.09V6.27L10.5,3L3,6.27v4.91c0,4.54,3.2,8.79,7.5,9.82c0.55-0.13,1.08-0.32,1.6-0.55 C11.41,19.47,11,18.28,11,17C11,13.69,13.69,11,17,11z\"/><path d=\"M17,13c-2.21,0-4,1.79-4,4c0,2.21,1.79,4,4,4s4-1.79,4-4C21,14.79,19.21,13,17,13z M17,14.38c0.62,0,1.12,0.51,1.12,1.12 s-0.51,1.12-1.12,1.12s-1.12-0.51-1.12-1.12S16.38,14.38,17,14.38z M17,19.75c-0.93,0-1.74-0.46-2.24-1.17 c0.05-0.72,1.51-1.08,2.24-1.08s2.19,0.36,2.24,1.08C18.74,19.29,17.93,19.75,17,19.75z\"/></g></g>", true, false, 98, null, "adminrole", "Admin" },
                    { 3, "docupload", null, true, false, 0, 2, null, "Upload Documents" },
                    { 5, "https://github.com/karan/Projects", null, true, true, 0, 4, null, "Projects" },
                    { 6, "https://github.com/karan/Projects-Solutions", null, true, true, 1, 4, null, "Solutions" },
                    { 8, "managenav", null, true, false, 0, 7, "adminrole", "Navigation" },
                    { 9, "docsearch", null, true, false, 0, 2, null, "Search Documents" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_NavLinks_ParentId",
                table: "Data_NavLinks",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data_NavLinks");
        }
    }
}
