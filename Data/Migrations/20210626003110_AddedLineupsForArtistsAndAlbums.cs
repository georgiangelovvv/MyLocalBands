using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLocalBands.Data.Migrations
{
    public partial class AddedLineupsForArtistsAndAlbums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentMembers",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lineup",
                table: "Albums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMembers",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Lineup",
                table: "Albums");
        }
    }
}
