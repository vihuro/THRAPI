using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class referenciadoChaveEstrangeiraParaUsuarioCadastroTabelaIdentificaoMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tab_IdentificaoMaterial_tab_Usuario_tab_Usuario",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Tab_IdentificaoMaterial_tab_Usuario",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.DropColumn(
                name: "tab_Usuario",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_UsuarioAlteracaoId",
                table: "Tab_IdentificaoMaterial",
                column: "UsuarioAlteracaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tab_IdentificaoMaterial_tab_Usuario_UsuarioAlteracaoId",
                table: "Tab_IdentificaoMaterial",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tab_IdentificaoMaterial_tab_Usuario_UsuarioAlteracaoId",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Tab_IdentificaoMaterial_UsuarioAlteracaoId",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.AddColumn<Guid>(
                name: "tab_Usuario",
                table: "Tab_IdentificaoMaterial",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_tab_Usuario",
                table: "Tab_IdentificaoMaterial",
                column: "tab_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tab_IdentificaoMaterial_tab_Usuario_tab_Usuario",
                table: "Tab_IdentificaoMaterial",
                column: "tab_Usuario",
                principalTable: "tab_Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
