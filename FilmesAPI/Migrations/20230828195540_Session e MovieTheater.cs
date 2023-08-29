using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class SessioneMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "movieTheaterId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_movieTheaterId",
                table: "Sessions",
                column: "movieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheaters_movieTheaterId",
                table: "Sessions",
                column: "movieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheaters_movieTheaterId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_movieTheaterId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "movieTheaterId",
                table: "Sessions");
        }
    }
}
