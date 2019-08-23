using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLifeStyle.Data.Migrations
{
    public partial class AddTitleInPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Publications",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticlesCount",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ArticlesCount",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Books",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Articles",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
