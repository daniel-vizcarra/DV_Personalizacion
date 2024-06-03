using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DV_MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DV_Authors",
                columns: table => new
                {
                    DV_AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DV_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DV_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DV_Authors", x => x.DV_AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "DV_Books",
                columns: table => new
                {
                    DV_BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DV_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DV_AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DV_Books", x => x.DV_BookId);
                    table.ForeignKey(
                        name: "FK_DV_Books_DV_Authors_DV_AuthorId",
                        column: x => x.DV_AuthorId,
                        principalTable: "DV_Authors",
                        principalColumn: "DV_AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DV_Books_DV_AuthorId",
                table: "DV_Books",
                column: "DV_AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DV_Books");

            migrationBuilder.DropTable(
                name: "DV_Authors");
        }
    }
}
