using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovieTheatereFilm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheaters_movieTheaterId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "movieTheaterId",
                table: "Sessions",
                newName: "MovieTheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_movieTheaterId",
                table: "Sessions",
                newName: "IX_Sessions_MovieTheaterId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                columns: new[] { "FilmId", "MovieTheaterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "MovieTheaterId",
                table: "Sessions",
                newName: "movieTheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_MovieTheaterId",
                table: "Sessions",
                newName: "IX_Sessions_movieTheaterId");

            migrationBuilder.AlterColumn<int>(
                name: "movieTheaterId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheaters_movieTheaterId",
                table: "Sessions",
                column: "movieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }
    }
}
