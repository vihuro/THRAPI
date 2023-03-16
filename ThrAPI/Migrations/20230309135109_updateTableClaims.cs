using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateTableClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Claims_tab_Usuario_UsuarioCadatroId",
                table: "tab_Claims");

            migrationBuilder.DropIndex(
                name: "IX_tab_Claims_UsuarioCadatroId",
                table: "tab_Claims");

            migrationBuilder.DropColumn(
                name: "UsuarioCadatroId",
                table: "tab_Claims");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Claims_UsuarioCadastroId",
                table: "tab_Claims",
                column: "UsuarioCadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Claims_tab_Usuario_UsuarioCadastroId",
                table: "tab_Claims",
                column: "UsuarioCadastroId",
                principalTable: "tab_Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Claims_tab_Usuario_UsuarioCadastroId",
                table: "tab_Claims");

            migrationBuilder.DropIndex(
                name: "IX_tab_Claims_UsuarioCadastroId",
                table: "tab_Claims");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCadatroId",
                table: "tab_Claims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_Claims_UsuarioCadatroId",
                table: "tab_Claims",
                column: "UsuarioCadatroId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Claims_tab_Usuario_UsuarioCadatroId",
                table: "tab_Claims",
                column: "UsuarioCadatroId",
                principalTable: "tab_Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
