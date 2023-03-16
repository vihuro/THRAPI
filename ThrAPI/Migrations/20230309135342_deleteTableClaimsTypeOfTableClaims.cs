using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteTableClaimsTypeOfTableClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "tab_Claims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClaimId",
                table: "tab_Claims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
