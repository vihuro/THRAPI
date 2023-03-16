using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class colunaDeletedaComChaveEstrangeiraParaMovimentacaoIdentificao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_Ident~",
                table: "tab_MovimentacaoIdentificacao");

            migrationBuilder.DropIndex(
                name: "IX_tab_MovimentacaoIdentificacao_IdentificaoMaterialId",
                table: "tab_MovimentacaoIdentificacao");

            migrationBuilder.DropColumn(
                name: "MovimentacaoIdentificaoId",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.AddColumn<Guid>(
                name: "tab_MovimentacaoIdentificacao",
                table: "tab_MovimentacaoIdentificacao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoIdentificacao_tab_MovimentacaoIdentificacao",
                table: "tab_MovimentacaoIdentificacao",
                column: "tab_MovimentacaoIdentificacao");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_tab_M~",
                table: "tab_MovimentacaoIdentificacao",
                column: "tab_MovimentacaoIdentificacao",
                principalTable: "Tab_IdentificaoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_tab_M~",
                table: "tab_MovimentacaoIdentificacao");

            migrationBuilder.DropIndex(
                name: "IX_tab_MovimentacaoIdentificacao_tab_MovimentacaoIdentificacao",
                table: "tab_MovimentacaoIdentificacao");

            migrationBuilder.DropColumn(
                name: "tab_MovimentacaoIdentificacao",
                table: "tab_MovimentacaoIdentificacao");

            migrationBuilder.AddColumn<Guid>(
                name: "MovimentacaoIdentificaoId",
                table: "Tab_IdentificaoMaterial",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoIdentificacao_IdentificaoMaterialId",
                table: "tab_MovimentacaoIdentificacao",
                column: "IdentificaoMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_Ident~",
                table: "tab_MovimentacaoIdentificacao",
                column: "IdentificaoMaterialId",
                principalTable: "Tab_IdentificaoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
