using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPhoto",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    PhotosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPhoto", x => new { x.CategoriesId, x.PhotosId });
                    table.ForeignKey(
                        name: "FK_CategoryPhoto_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPhoto_photo_PhotosId",
                        column: x => x.PhotosId,
                        principalTable: "photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPhoto_PhotosId",
                table: "CategoryPhoto",
                column: "PhotosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPhoto");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "photo");
        }
    }
}
