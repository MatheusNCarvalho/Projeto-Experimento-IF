﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFExperiment.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Experimentos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    Excluido = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataConclusao = table.Column<DateTime>(nullable: true),
                    QtdRepeticao = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntidades",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    EntidadeAnterior = table.Column<string>(nullable: true),
                    EntidadeNova = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    NomeClass = table.Column<string>(nullable: true),
                    Acao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tratamentos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    Excluido = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    Excluido = table.Column<int>(nullable: false),
                    NomeBloco = table.Column<string>(type: "varchar(5)", nullable: false),
                    ExperimentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocos_Experimentos_ExperimentoId",
                        column: x => x.ExperimentoId,
                        principalSchema: "public",
                        principalTable: "Experimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentosTratamentos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    Excluido = table.Column<int>(nullable: false),
                    ExperimentoId = table.Column<Guid>(nullable: false),
                    TratamentoId = table.Column<Guid>(nullable: false),
                    Qtd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentosTratamentos", x => new { x.ExperimentoId, x.TratamentoId });
                    table.ForeignKey(
                        name: "FK_ExperimentosTratamentos_Experimentos_ExperimentoId",
                        column: x => x.ExperimentoId,
                        principalSchema: "public",
                        principalTable: "Experimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperimentosTratamentos_Tratamentos_TratamentoId",
                        column: x => x.TratamentoId,
                        principalSchema: "public",
                        principalTable: "Tratamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlocosTratamentos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    Excluido = table.Column<int>(nullable: false),
                    OrdemSequencia = table.Column<int>(nullable: false),
                    NomeParcela = table.Column<string>(type: "varchar(5)", nullable: false),
                    TratamentoId = table.Column<Guid>(nullable: false),
                    BlocoId = table.Column<Guid>(nullable: false),
                    DataAvaliacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlocosTratamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlocosTratamentos_Blocos_BlocoId",
                        column: x => x.BlocoId,
                        principalSchema: "public",
                        principalTable: "Blocos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlocosTratamentos_Tratamentos_TratamentoId",
                        column: x => x.TratamentoId,
                        principalSchema: "public",
                        principalTable: "Tratamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_ExperimentoId",
                schema: "public",
                table: "Blocos",
                column: "ExperimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_BlocosTratamentos_BlocoId",
                schema: "public",
                table: "BlocosTratamentos",
                column: "BlocoId");

            migrationBuilder.CreateIndex(
                name: "IX_BlocosTratamentos_TratamentoId",
                schema: "public",
                table: "BlocosTratamentos",
                column: "TratamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentosTratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "TratamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlocosTratamentos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ExperimentosTratamentos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LogEntidades",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Blocos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tratamentos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Experimentos",
                schema: "public");
        }
    }
}
