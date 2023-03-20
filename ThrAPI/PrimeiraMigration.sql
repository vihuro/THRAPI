CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "tab_Usuario" (
    "Id" uuid NOT NULL,
    "NomeUsuario" text NOT NULL,
    "Apelido" text NOT NULL,
    "Senha" text NOT NULL,
    CONSTRAINT "PK_tab_Usuario" PRIMARY KEY ("Id")
);

CREATE TABLE "tab_ClaimsType" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Value" text NOT NULL,
    "UsuarioCadastroId" uuid NOT NULL,
    "DataHoraCadatro" timestamp with time zone NOT NULL,
    "UsuarioAlteracaoId" uuid NOT NULL,
    "DataHoraAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_tab_ClaimsType" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_tab_ClaimsType_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_ClaimsType_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "tab_Estoque" (
    "Id" uuid NOT NULL,
    "Codigo" text NOT NULL,
    "Descricao" text NOT NULL,
    "Unidade" text NOT NULL,
    "Fornecedor" text NOT NULL,
    "CategoriaA" text NOT NULL,
    "CategoriaB" text NOT NULL,
    "CategoriaC" text NOT NULL,
    "QuantidadeEstoque" numeric NOT NULL,
    "EstoqueSeguranca" numeric NOT NULL,
    "EstoqueMinimo" numeric NOT NULL,
    "EstoqueMaximo" numeric NOT NULL,
    "UsuarioCadastroId" uuid NOT NULL,
    "DataHoraCadastro" timestamp with time zone NOT NULL,
    "UsuarioAlteracaoId" uuid NOT NULL,
    "DataHoraAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_tab_Estoque" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_tab_Estoque_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_Estoque_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Tab_LocaisEstocagem" (
    "Id" uuid NOT NULL,
    "NomeLocal" text NOT NULL,
    "StatusLocal" text NOT NULL,
    "DataHoraCriacao" timestamp with time zone NOT NULL,
    "DataHoraAlteracao" timestamp with time zone NOT NULL,
    "UsuarioCadastroId" uuid NOT NULL,
    "UsuarioAlteracaoId" uuid NOT NULL,
    CONSTRAINT "PK_Tab_LocaisEstocagem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Tab_LocaisEstocagem_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Tab_LocaisEstocagem_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "tab_Claims" (
    "Id" uuid NOT NULL,
    "ClaimId" uuid NOT NULL,
    "ClaimsTypeId" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "UsuarioCadastroId" uuid NOT NULL,
    "UsuarioCadatroId" uuid NOT NULL,
    "DataHoraCadastro" timestamp with time zone NOT NULL,
    "UsuarioAlteracaoId" uuid NOT NULL,
    "DataHoraAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_tab_Claims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_tab_Claims_tab_ClaimsType_ClaimsTypeId" FOREIGN KEY ("ClaimsTypeId") REFERENCES "tab_ClaimsType" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_Claims_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_Claims_tab_Usuario_UsuarioCadatroId" FOREIGN KEY ("UsuarioCadatroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_Claims_tab_Usuario_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Tab_IdentificaoMaterial" (
    "Id" uuid NOT NULL,
    "ProdutoId" uuid NOT NULL,
    "Lote" text NULL,
    "PesoPalete" numeric NULL,
    "PesoBruto" numeric NULL,
    "PesoLiquido" numeric NULL,
    "Quantidade" numeric NULL,
    "UsuarioCadastroId" uuid NOT NULL,
    "DataHoraCadastro" timestamp with time zone NOT NULL,
    "UsuarioAlteracaoId" uuid NOT NULL,
    "tab_Usuario" uuid NOT NULL,
    "DataHoraAlteracao" timestamp with time zone NOT NULL,
    "IF" numeric NULL,
    "Densidade" numeric NULL,
    "TipoMaterial" text NOT NULL,
    "MovimentacaoIdentificaoId" uuid NOT NULL,
    CONSTRAINT "PK_Tab_IdentificaoMaterial" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Tab_IdentificaoMaterial_tab_Estoque_ProdutoId" FOREIGN KEY ("ProdutoId") REFERENCES "tab_Estoque" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Tab_IdentificaoMaterial_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Tab_IdentificaoMaterial_tab_Usuario_tab_Usuario" FOREIGN KEY ("tab_Usuario") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "tab_MovimentacaoIdentificacao" (
    "Id" uuid NOT NULL,
    "IdentificaoMaterialId" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "tab_Usuario" uuid NOT NULL,
    "DataHoraMovimentacao" timestamp with time zone NOT NULL,
    "QuantidadeMovimentada" numeric NOT NULL,
    "LocalOrigemId" uuid NOT NULL,
    "LocalDestinoId" uuid NOT NULL,
    CONSTRAINT "PK_tab_MovimentacaoIdentificacao" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_Ident~" FOREIGN KEY ("IdentificaoMaterialId") REFERENCES "Tab_IdentificaoMaterial" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_MovimentacaoIdentificacao_Tab_LocaisEstocagem_LocalDest~" FOREIGN KEY ("LocalDestinoId") REFERENCES "Tab_LocaisEstocagem" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_MovimentacaoIdentificacao_Tab_LocaisEstocagem_LocalOrig~" FOREIGN KEY ("LocalOrigemId") REFERENCES "Tab_LocaisEstocagem" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_MovimentacaoIdentificacao_tab_Usuario_tab_Usuario" FOREIGN KEY ("tab_Usuario") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "tab_MovimentacaoMaterial" (
    "Id" uuid NOT NULL,
    "TipoMovimentacao" text NOT NULL,
    "QuantidadeMovimentada" numeric NOT NULL,
    "DataHoraMovimentacao" timestamp with time zone NOT NULL,
    "StatusMovimentacao" text NOT NULL,
    "EstoqueId" uuid NOT NULL,
    "UsuarioMovimentacaoId" uuid NOT NULL,
    "IdentificaoId" uuid NULL,
    CONSTRAINT "PK_tab_MovimentacaoMaterial" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_tab_MovimentacaoMaterial_Tab_IdentificaoMaterial_Identifica~" FOREIGN KEY ("IdentificaoId") REFERENCES "Tab_IdentificaoMaterial" ("Id"),
    CONSTRAINT "FK_tab_MovimentacaoMaterial_tab_Estoque_EstoqueId" FOREIGN KEY ("EstoqueId") REFERENCES "tab_Estoque" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_tab_MovimentacaoMaterial_tab_Usuario_UsuarioMovimentacaoId" FOREIGN KEY ("UsuarioMovimentacaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_tab_Claims_ClaimsTypeId" ON "tab_Claims" ("ClaimsTypeId");

CREATE INDEX "IX_tab_Claims_UsuarioAlteracaoId" ON "tab_Claims" ("UsuarioAlteracaoId");

CREATE INDEX "IX_tab_Claims_UsuarioCadatroId" ON "tab_Claims" ("UsuarioCadatroId");

CREATE INDEX "IX_tab_Claims_UsuarioId" ON "tab_Claims" ("UsuarioId");

CREATE INDEX "IX_tab_ClaimsType_UsuarioAlteracaoId" ON "tab_ClaimsType" ("UsuarioAlteracaoId");

CREATE INDEX "IX_tab_ClaimsType_UsuarioCadastroId" ON "tab_ClaimsType" ("UsuarioCadastroId");

CREATE INDEX "IX_tab_Estoque_UsuarioAlteracaoId" ON "tab_Estoque" ("UsuarioAlteracaoId");

CREATE INDEX "IX_tab_Estoque_UsuarioCadastroId" ON "tab_Estoque" ("UsuarioCadastroId");

CREATE INDEX "IX_Tab_IdentificaoMaterial_ProdutoId" ON "Tab_IdentificaoMaterial" ("ProdutoId");

CREATE INDEX "IX_Tab_IdentificaoMaterial_tab_Usuario" ON "Tab_IdentificaoMaterial" ("tab_Usuario");

CREATE INDEX "IX_Tab_IdentificaoMaterial_UsuarioCadastroId" ON "Tab_IdentificaoMaterial" ("UsuarioCadastroId");

CREATE INDEX "IX_Tab_LocaisEstocagem_UsuarioAlteracaoId" ON "Tab_LocaisEstocagem" ("UsuarioAlteracaoId");

CREATE INDEX "IX_Tab_LocaisEstocagem_UsuarioCadastroId" ON "Tab_LocaisEstocagem" ("UsuarioCadastroId");

CREATE INDEX "IX_tab_MovimentacaoIdentificacao_IdentificaoMaterialId" ON "tab_MovimentacaoIdentificacao" ("IdentificaoMaterialId");

CREATE INDEX "IX_tab_MovimentacaoIdentificacao_LocalDestinoId" ON "tab_MovimentacaoIdentificacao" ("LocalDestinoId");

CREATE INDEX "IX_tab_MovimentacaoIdentificacao_LocalOrigemId" ON "tab_MovimentacaoIdentificacao" ("LocalOrigemId");

CREATE INDEX "IX_tab_MovimentacaoIdentificacao_tab_Usuario" ON "tab_MovimentacaoIdentificacao" ("tab_Usuario");

CREATE INDEX "IX_tab_MovimentacaoMaterial_EstoqueId" ON "tab_MovimentacaoMaterial" ("EstoqueId");

CREATE INDEX "IX_tab_MovimentacaoMaterial_IdentificaoId" ON "tab_MovimentacaoMaterial" ("IdentificaoId");

CREATE INDEX "IX_tab_MovimentacaoMaterial_UsuarioMovimentacaoId" ON "tab_MovimentacaoMaterial" ("UsuarioMovimentacaoId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230309134914_TableClaims', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "tab_Claims" DROP CONSTRAINT "FK_tab_Claims_tab_Usuario_UsuarioCadatroId";

DROP INDEX "IX_tab_Claims_UsuarioCadatroId";

ALTER TABLE "tab_Claims" DROP COLUMN "UsuarioCadatroId";

CREATE INDEX "IX_tab_Claims_UsuarioCadastroId" ON "tab_Claims" ("UsuarioCadastroId");

ALTER TABLE "tab_Claims" ADD CONSTRAINT "FK_tab_Claims_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230309135109_updateTableClaims', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "tab_Claims" DROP COLUMN "ClaimId";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230309135342_deleteTableClaimsTypeOfTableClaims', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "Tab_LocaisEstocagem" ADD "NumeroLocal" integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230310215113_TableLocaisEstocagemNumeroRua', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "Tab_IdentificaoMaterial" ADD "LocalEstocagemId" uuid NULL;

CREATE INDEX "IX_Tab_IdentificaoMaterial_LocalEstocagemId" ON "Tab_IdentificaoMaterial" ("LocalEstocagemId");

ALTER TABLE "Tab_IdentificaoMaterial" ADD CONSTRAINT "FK_Tab_IdentificaoMaterial_Tab_LocaisEstocagem_LocalEstocagemId" FOREIGN KEY ("LocalEstocagemId") REFERENCES "Tab_LocaisEstocagem" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316011316_ColunaIdLocalEstocagem', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "Tab_IdentificaoMaterial" ALTER COLUMN "IF" TYPE text;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316121518_updateForStringIF', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "tab_MovimentacaoIdentificacao" DROP CONSTRAINT "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_Ident~";

DROP INDEX "IX_tab_MovimentacaoIdentificacao_IdentificaoMaterialId";

ALTER TABLE "Tab_IdentificaoMaterial" DROP COLUMN "MovimentacaoIdentificaoId";

ALTER TABLE "tab_MovimentacaoIdentificacao" ADD "tab_MovimentacaoIdentificacao" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

CREATE INDEX "IX_tab_MovimentacaoIdentificacao_tab_MovimentacaoIdentificacao" ON "tab_MovimentacaoIdentificacao" ("tab_MovimentacaoIdentificacao");

ALTER TABLE "tab_MovimentacaoIdentificacao" ADD CONSTRAINT "FK_tab_MovimentacaoIdentificacao_Tab_IdentificaoMaterial_tab_M~" FOREIGN KEY ("tab_MovimentacaoIdentificacao") REFERENCES "Tab_IdentificaoMaterial" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316121639_colunaDeletedaComChaveEstrangeiraParaMovimentacaoIdentificao', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "Tab_IdentificaoMaterial" DROP COLUMN "TipoMaterial";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316122149_removidoColunaTipoMaterialTabelaIdentificaoMaterial', '7.0.3');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316130200_updateTableIdentificao', '7.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "Tab_IdentificaoMaterial" DROP CONSTRAINT "FK_Tab_IdentificaoMaterial_tab_Usuario_tab_Usuario";

DROP INDEX "IX_Tab_IdentificaoMaterial_tab_Usuario";

ALTER TABLE "Tab_IdentificaoMaterial" DROP COLUMN "tab_Usuario";

CREATE INDEX "IX_Tab_IdentificaoMaterial_UsuarioAlteracaoId" ON "Tab_IdentificaoMaterial" ("UsuarioAlteracaoId");

ALTER TABLE "Tab_IdentificaoMaterial" ADD CONSTRAINT "FK_Tab_IdentificaoMaterial_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316130536_referenciadoChaveEstrangeiraParaUsuarioCadastroTabelaIdentificaoMaterial', '7.0.3');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230316172529_update', '7.0.3');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230317172530_lastUPdate', '7.0.3');

COMMIT;

