using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    /// <inheritdoc />
    public partial class AddFkArtistToMusic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistsId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ArtistsId",
                table: "Musics",
                column: "ArtistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ArtistsId",
                table: "Musics",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ArtistsId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ArtistsId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ArtistsId",
                table: "Musics");

        }
    }
}
