using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLocalBands.Data.Migrations
{
    public partial class AddedAlbumTypeSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AlbumTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Demo" },
                    { 2, "Single" },
                    { 3, "EP" },
                    { 4, "Compilation" },
                    { 5, "Live album" },
                    { 6, "Full-length" },
                    { 7, "Video" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AlbumTypes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
