using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daily_stream_cms.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminArticleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminArticle",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminArticle", x => new { x.AdminId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_AdminArticle_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminArticle_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminArticle_ArticleId",
                table: "AdminArticle",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminArticle");
        }
    }
}
