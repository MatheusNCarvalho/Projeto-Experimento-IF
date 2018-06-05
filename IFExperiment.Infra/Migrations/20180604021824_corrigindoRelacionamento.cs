using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFExperiment.Infra.Migrations
{
    public partial class corrigindoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperimentoTratamentoId",
                schema: "public",
                table: "Tramentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExperimentoTratamentoId",
                schema: "public",
                table: "Tramentos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
