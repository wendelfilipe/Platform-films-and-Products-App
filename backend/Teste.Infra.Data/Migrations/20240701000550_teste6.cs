using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class teste6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_movies_MovieId",
                schema: "traffic",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                schema: "traffic",
                table: "user",
                newName: "movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_MovieId",
                schema: "traffic",
                table: "user",
                newName: "IX_user_movie_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_movies_movie_id",
                schema: "traffic",
                table: "user",
                column: "movie_id",
                principalSchema: "platform",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_movies_movie_id",
                schema: "traffic",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                schema: "traffic",
                table: "user",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_user_movie_id",
                schema: "traffic",
                table: "user",
                newName: "IX_user_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_movies_MovieId",
                schema: "traffic",
                table: "user",
                column: "MovieId",
                principalSchema: "platform",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
