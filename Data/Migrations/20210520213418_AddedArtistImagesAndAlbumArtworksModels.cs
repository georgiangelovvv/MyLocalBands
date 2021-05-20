using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLocalBands.Data.Migrations
{
    public partial class AddedArtistImagesAndAlbumArtworksModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Albums");

            migrationBuilder.CreateTable(
                name: "AlbumArtworks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumArtworks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistImages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistImages_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtworks_AlbumId",
                table: "AlbumArtworks",
                column: "AlbumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistImages_ArtistId",
                table: "ArtistImages",
                column: "ArtistId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtworks");

            migrationBuilder.DropTable(
                name: "ArtistImages");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
