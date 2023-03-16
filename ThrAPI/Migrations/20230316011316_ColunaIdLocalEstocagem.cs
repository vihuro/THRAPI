using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColunaIdLocalEstocagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocalEstocagemId",
                table: "Tab_IdentificaoMaterial",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_LocalEstocagemId",
                table: "Tab_IdentificaoMaterial",
                column: "LocalEstocagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tab_IdentificaoMaterial_Tab_LocaisEstocagem_LocalEstocagemId",
                table: "Tab_IdentificaoMaterial",
                column: "LocalEstocagemId",
                principalTable: "Tab_LocaisEstocagem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tab_IdentificaoMaterial_Tab_LocaisEstocagem_LocalEstocagemId",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Tab_IdentificaoMaterial_LocalEstocagemId",
                table: "Tab_IdentificaoMaterial");

            migrationBuilder.DropColumn(
                name: "LocalEstocagemId",
                table: "Tab_IdentificaoMaterial");
        }
    }
}
