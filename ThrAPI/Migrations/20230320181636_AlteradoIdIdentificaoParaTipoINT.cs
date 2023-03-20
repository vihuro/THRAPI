using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThrAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoIdIdentificaoParaTipoINT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeUsuario = table.Column<string>(type: "text", nullable: false),
                    Apelido = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_ClaimsType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadatro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ClaimsType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsType_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsType_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Unidade = table.Column<string>(type: "text", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: false),
                    CategoriaA = table.Column<string>(type: "text", nullable: false),
                    CategoriaB = table.Column<string>(type: "text", nullable: false),
                    CategoriaC = table.Column<string>(type: "text", nullable: false),
                    QuantidadeEstoque = table.Column<decimal>(type: "numeric", nullable: false),
                    EstoqueSeguranca = table.Column<decimal>(type: "numeric", nullable: false),
                    EstoqueMinimo = table.Column<decimal>(type: "numeric", nullable: false),
                    EstoqueMaximo = table.Column<decimal>(type: "numeric", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Estoque_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Estoque_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tab_LocaisEstocagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeLocal = table.Column<string>(type: "text", nullable: false),
                    NumeroLocal = table.Column<int>(type: "integer", nullable: false),
                    StatusLocal = table.Column<string>(type: "text", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_LocaisEstocagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tab_LocaisEstocagem_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tab_LocaisEstocagem_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimsTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Claims_tab_ClaimsType_ClaimsTypeId",
                        column: x => x.ClaimsTypeId,
                        principalTable: "tab_ClaimsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Claims_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Claims_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Claims_tab_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tab_IdentificaoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Lote = table.Column<string>(type: "text", nullable: true),
                    PesoPalete = table.Column<decimal>(type: "numeric", nullable: true),
                    PesoBruto = table.Column<decimal>(type: "numeric", nullable: true),
                    PesoLiquido = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantidade = table.Column<decimal>(type: "numeric", nullable: true),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IF = table.Column<string>(type: "text", nullable: true),
                    Densidade = table.Column<decimal>(type: "numeric", nullable: true),
                    LocalEstocagemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_IdentificaoMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tab_IdentificaoMaterial_Tab_LocaisEstocagem_LocalEstocagemId",
                        column: x => x.LocalEstocagemId,
                        principalTable: "Tab_LocaisEstocagem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tab_IdentificaoMaterial_tab_Estoque_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tab_Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tab_IdentificaoMaterial_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tab_IdentificaoMaterial_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_MovimentacaoIdentificacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentificaoMaterialId = table.Column<int>(type: "integer", nullable: false),
                    tab_MovimentacaoIdentificacao = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    tab_Usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantidadeMovimentada = table.Column<decimal>(type: "numeric", nullable: false),
                    LocalOrigemId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalDestinoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_MovimentacaoIdentificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_tab_M~",
                        column: x => x.tab_MovimentacaoIdentificacao,
                        principalTable: "Tab_IdentificaoMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoIdentificacao_Tab_LocaisEstocagem_LocalDest~",
                        column: x => x.LocalDestinoId,
                        principalTable: "Tab_LocaisEstocagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoIdentificacao_Tab_LocaisEstocagem_LocalOrig~",
                        column: x => x.LocalOrigemId,
                        principalTable: "Tab_LocaisEstocagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoIdentificacao_tab_Usuario_tab_Usuario",
                        column: x => x.tab_Usuario,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_MovimentacaoMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoMovimentacao = table.Column<string>(type: "text", nullable: false),
                    QuantidadeMovimentada = table.Column<decimal>(type: "numeric", nullable: false),
                    DataHoraMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusMovimentacao = table.Column<string>(type: "text", nullable: false),
                    EstoqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioMovimentacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentificaoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_MovimentacaoMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoMaterial_Tab_IdentificaoMaterial_Identifica~",
                        column: x => x.IdentificaoId,
                        principalTable: "Tab_IdentificaoMaterial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoMaterial_tab_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "tab_Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_MovimentacaoMaterial_tab_Usuario_UsuarioMovimentacaoId",
                        column: x => x.UsuarioMovimentacaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_Claims_ClaimsTypeId",
                table: "tab_Claims",
                column: "ClaimsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Claims_UsuarioAlteracaoId",
                table: "tab_Claims",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Claims_UsuarioCadastroId",
                table: "tab_Claims",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Claims_UsuarioId",
                table: "tab_Claims",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsType_UsuarioAlteracaoId",
                table: "tab_ClaimsType",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsType_UsuarioCadastroId",
                table: "tab_ClaimsType",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Estoque_UsuarioAlteracaoId",
                table: "tab_Estoque",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Estoque_UsuarioCadastroId",
                table: "tab_Estoque",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_LocalEstocagemId",
                table: "Tab_IdentificaoMaterial",
                column: "LocalEstocagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_ProdutoId",
                table: "Tab_IdentificaoMaterial",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_UsuarioAlteracaoId",
                table: "Tab_IdentificaoMaterial",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_IdentificaoMaterial_UsuarioCadastroId",
                table: "Tab_IdentificaoMaterial",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_LocaisEstocagem_UsuarioAlteracaoId",
                table: "Tab_LocaisEstocagem",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_LocaisEstocagem_UsuarioCadastroId",
                table: "Tab_LocaisEstocagem",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoIdentificacao_LocalDestinoId",
                table: "tab_MovimentacaoIdentificacao",
                column: "LocalDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoIdentificacao_LocalOrigemId",
                table: "tab_MovimentacaoIdentificacao",
                column: "LocalOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoIdentificacao_tab_MovimentacaoIdentificacao",
                table: "tab_MovimentacaoIdentificacao",
                column: "tab_MovimentacaoIdentificacao");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoIdentificacao_tab_Usuario",
                table: "tab_MovimentacaoIdentificacao",
                column: "tab_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoMaterial_EstoqueId",
                table: "tab_MovimentacaoMaterial",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoMaterial_IdentificaoId",
                table: "tab_MovimentacaoMaterial",
                column: "IdentificaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_MovimentacaoMaterial_UsuarioMovimentacaoId",
                table: "tab_MovimentacaoMaterial",
                column: "UsuarioMovimentacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_Claims");

            migrationBuilder.DropTable(
                name: "tab_MovimentacaoIdentificacao");

            migrationBuilder.DropTable(
                name: "tab_MovimentacaoMaterial");

            migrationBuilder.DropTable(
                name: "tab_ClaimsType");

            migrationBuilder.DropTable(
                name: "Tab_IdentificaoMaterial");

            migrationBuilder.DropTable(
                name: "Tab_LocaisEstocagem");

            migrationBuilder.DropTable(
                name: "tab_Estoque");

            migrationBuilder.DropTable(
                name: "tab_Usuario");
        }
    }
}
