using Microsoft.EntityFrameworkCore.Migrations;

namespace IFExperiment.Infra.Migrations
{
    public partial class corrigindoRelacionamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlocosTratamentos_Tramentos_TratamentoId",
                schema: "public",
                table: "BlocosTratamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentosTratamentos_Tramentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperimentosTratamentos",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropIndex(
                name: "IX_ExperimentosTratamentos_ExperimentoId",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropIndex(
                name: "IX_ExperimentosTratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tramentos",
                schema: "public",
                table: "Tramentos");

            migrationBuilder.RenameTable(
                name: "Tramentos",
                schema: "public",
                newName: "Tratamentos",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperimentosTratamentos",
                schema: "public",
                table: "ExperimentosTratamentos",
                columns: new[] { "ExperimentoId", "TratamentoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tratamentos",
                schema: "public",
                table: "Tratamentos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentosTratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "TratamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlocosTratamentos_Tratamentos_TratamentoId",
                schema: "public",
                table: "BlocosTratamentos",
                column: "TratamentoId",
                principalSchema: "public",
                principalTable: "Tratamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentosTratamentos_Tratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "TratamentoId",
                principalSchema: "public",
                principalTable: "Tratamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlocosTratamentos_Tratamentos_TratamentoId",
                schema: "public",
                table: "BlocosTratamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentosTratamentos_Tratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperimentosTratamentos",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropIndex(
                name: "IX_ExperimentosTratamentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tratamentos",
                schema: "public",
                table: "Tratamentos");

            migrationBuilder.RenameTable(
                name: "Tratamentos",
                schema: "public",
                newName: "Tramentos",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperimentosTratamentos",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tramentos",
                schema: "public",
                table: "Tramentos",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BlocosTratamentos_Tramentos_TratamentoId",
                schema: "public",
                table: "BlocosTratamentos",
                column: "TratamentoId",
                principalSchema: "public",
                principalTable: "Tramentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentosTratamentos_Tramentos_TratamentoId",
                schema: "public",
                table: "ExperimentosTratamentos",
                column: "TratamentoId",
                principalSchema: "public",
                principalTable: "Tramentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
