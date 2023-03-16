using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class TableLocaisEstocagemNumeroRua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroLocal",
                table: "Tab_LocaisEstocagem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroLocal",
                table: "Tab_LocaisEstocagem");
        }
    }
}
