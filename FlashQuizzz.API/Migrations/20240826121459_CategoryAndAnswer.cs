using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlashQuizzz.API.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashCardCategoryID",
                table: "FlashCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlashCardCategory",
                columns: table => new
                {
                    FlashCardCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlashCardCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlashCardCategoryStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardCategory", x => x.FlashCardCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardAnswer",
                columns: table => new
                {
                    FlashCardAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlashCardAnswerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlashCardIsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlashCardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardAnswer", x => x.FlashCardAnswerID);
                    table.ForeignKey(
                        name: "FK_FlashCardAnswer_FlashCardCategory_FlashCardID",
                        column: x => x.FlashCardID,
                        principalTable: "FlashCardCategory",
                        principalColumn: "FlashCardCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FlashCardCategory",
                columns: new[] { "FlashCardCategoryID", "CreatedDate", "FlashCardCategoryName", "FlashCardCategoryStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML", true },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSS", true },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JS", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCard_FlashCardCategoryID",
                table: "FlashCard",
                column: "FlashCardCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardAnswer_FlashCardID",
                table: "FlashCardAnswer",
                column: "FlashCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_FlashCardCategory_FlashCardCategoryID",
                table: "FlashCard",
                column: "FlashCardCategoryID",
                principalTable: "FlashCardCategory",
                principalColumn: "FlashCardCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_FlashCardCategory_FlashCardCategoryID",
                table: "FlashCard");

            migrationBuilder.DropTable(
                name: "FlashCardAnswer");

            migrationBuilder.DropTable(
                name: "FlashCardCategory");

            migrationBuilder.DropIndex(
                name: "IX_FlashCard_FlashCardCategoryID",
                table: "FlashCard");

            migrationBuilder.DropColumn(
                name: "FlashCardCategoryID",
                table: "FlashCard");
        }
    }
}
