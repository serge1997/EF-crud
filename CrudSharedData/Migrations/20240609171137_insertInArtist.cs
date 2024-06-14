using Crud.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    /// <inheritdoc />
    public partial class insertInArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Artists",
             columns: new[] { "Name", "Bio", "Picture", "Birth" },
             values: new object[] { "Lourena", "Artista brasileira", "Picture", "1994" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artists");
        }
    }
}
