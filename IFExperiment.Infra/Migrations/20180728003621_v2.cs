using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFExperiment.Infra.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "public",
                table: "Tratamentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConclusao",
                schema: "public",
                table: "Experimentos",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "public",
                table: "Tratamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConclusao",
                schema: "public",
                table: "Experimentos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
