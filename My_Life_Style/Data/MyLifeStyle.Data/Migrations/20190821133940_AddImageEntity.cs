using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLifeStyle.Data.Migrations
{
    public partial class AddImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Articles",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Publications",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Publications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    SizeInBytes = table.Column<int>(nullable: false),
                    PublicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PublicationId",
                table: "Images",
                column: "PublicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Comments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "Content");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Publications",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Publications",
                nullable: true);
        }
    }
}
