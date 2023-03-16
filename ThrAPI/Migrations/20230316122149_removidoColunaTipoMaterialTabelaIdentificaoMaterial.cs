using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class removidoColunaTipoMaterialTabelaIdentificaoMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMaterial",
                table: "Tab_IdentificaoMaterial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoMaterial",
                table: "Tab_IdentificaoMaterial",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
