using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFExperiment.Infra.Migrations
{
    public partial class InicioBanco : Migration
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
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataConclusao = table.Column<DateTime>(nullable: false),
                    QtdRepeticao = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tramentos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ExperimentoTratamentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreasExperimentos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<int>(nullable: false),
                    ExperimentroId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasExperimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreasExperimentos_Experimentos_ExperimentroId",
                        column: x => x.ExperimentroId,
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
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<int>(nullable: false),
                    ExperimentoId = table.Column<Guid>(nullable: false),
                    TratamentoId = table.Column<Guid>(nullable: false),
                    Qtd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentosTratamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentosTratamentos_Experimentos_ExperimentoId",
                        column: x => x.ExperimentoId,
                        principalSchema: "public",
                        principalTable: "Experimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperimentosTratamentos_Tramentos_TratamentoId",
                        column: x => x.TratamentoId,
                        principalSchema: "public",
                        principalTable: "Tramentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastrado = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<int>(nullable: false),
                    NomeBloco = table.Column<string>(type: "varchar(5)", nullable: false),
                    AreaExperimentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocos_AreasExperimentos_AreaExperimentoId",
                        column: x => x.AreaExperimentoId,
                        principalSchema: "public",
                        principalTable: "AreasExperimentos",
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
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<int>(nullable: false),
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
                        name: "FK_BlocosTratamentos_Tramentos_TratamentoId",
                        column: x => x.TratamentoId,
                        principalSchema: "public",
                        principalTable: "Tramentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreasExperimentos_ExperimentroId",
                schema: "public",
                table: "AreasExperimentos",
                column: "ExperimentroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_AreaExperimentoId",
                schema: "public",
                table: "Blocos",
                column: "AreaExperimentoId");

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
                name: "IX_ExperimentosTratamentos_ExperimentoId",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "ExperimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentosTratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "TratamentoId",
                unique: true);
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
                name: "Blocos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tramentos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AreasExperimentos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Experimentos",
                schema: "public");
        }
    }
}
