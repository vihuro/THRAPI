﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThrAPI.Context;

#nullable disable

namespace ThrAPI.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20230309135109_updateTableClaims")]
    partial class updateTableClaims
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThrAPI.Models.Estoque.EstoqueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoriaA")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CategoriaB")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CategoriaC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("EstoqueMaximo")
                        .HasColumnType("numeric");

                    b.Property<decimal>("EstoqueMinimo")
                        .HasColumnType("numeric");

                    b.Property<decimal>("EstoqueSeguranca")
                        .HasColumnType("numeric");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("QuantidadeEstoque")
                        .HasColumnType("numeric");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_Estoque");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.IdentificaoMaterialModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Densidade")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("IF")
                        .HasColumnType("numeric");

                    b.Property<string>("Lote")
                        .HasColumnType("text");

                    b.Property<Guid>("MovimentacaoIdentificaoId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("PesoBruto")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("PesoLiquido")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("PesoPalete")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Quantidade")
                        .HasColumnType("numeric");

                    b.Property<string>("TipoMaterial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("tab_Usuario")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.HasIndex("tab_Usuario");

                    b.ToTable("Tab_IdentificaoMaterial");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.LocaisEstocagemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeLocal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusLocal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("Tab_LocaisEstocagem");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.MovimentacaoIdentificaoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraMovimentacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdentificaoMaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocalDestinoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocalOrigemId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("QuantidadeMovimentada")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("tab_Usuario")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdentificaoMaterialId");

                    b.HasIndex("LocalDestinoId");

                    b.HasIndex("LocalOrigemId");

                    b.HasIndex("tab_Usuario");

                    b.ToTable("tab_MovimentacaoIdentificacao");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.MovimentaoEstoqueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraMovimentacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EstoqueId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdentificaoId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("QuantidadeMovimentada")
                        .HasColumnType("numeric");

                    b.Property<string>("StatusMovimentacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioMovimentacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("IdentificaoId");

                    b.HasIndex("UsuarioMovimentacaoId");

                    b.ToTable("tab_MovimentacaoMaterial");
                });

            modelBuilder.Entity("ThrAPI.Models.Login.ClaimsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClaimId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClaimsTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClaimsTypeId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tab_Claims");
                });

            modelBuilder.Entity("ThrAPI.Models.Login.ClaimsTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadatro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_ClaimsType");
                });

            modelBuilder.Entity("ThrAPI.Models.Login.UsuarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_Usuario");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.EstoqueModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.IdentificaoMaterialModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Estoque.EstoqueModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("tab_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.LocaisEstocagemModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.MovimentacaoIdentificaoModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Estoque.IdentificaoMaterialModel", "IdentificaoMaterial")
                        .WithMany("MovimentacaoIdentificao")
                        .HasForeignKey("IdentificaoMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Estoque.LocaisEstocagemModel", "LocalDestino")
                        .WithMany()
                        .HasForeignKey("LocalDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Estoque.LocaisEstocagemModel", "LocalOrigem")
                        .WithMany()
                        .HasForeignKey("LocalOrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("tab_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentificaoMaterial");

                    b.Navigation("LocalDestino");

                    b.Navigation("LocalOrigem");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.MovimentaoEstoqueModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Estoque.EstoqueModel", "Estoque")
                        .WithMany()
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Estoque.IdentificaoMaterialModel", "Identificao")
                        .WithMany()
                        .HasForeignKey("IdentificaoId");

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioMovimentacao")
                        .WithMany()
                        .HasForeignKey("UsuarioMovimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");

                    b.Navigation("Identificao");

                    b.Navigation("UsuarioMovimentacao");
                });

            modelBuilder.Entity("ThrAPI.Models.Login.ClaimsModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Login.ClaimsTypeModel", "ClaimsType")
                        .WithMany("ListClaimsOfUser")
                        .HasForeignKey("ClaimsTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClaimsType");

                    b.Navigation("Usuario");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ThrAPI.Models.Login.ClaimsTypeModel", b =>
                {
                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThrAPI.Models.Login.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ThrAPI.Models.Estoque.IdentificaoMaterialModel", b =>
                {
                    b.Navigation("MovimentacaoIdentificao");
                });

            modelBuilder.Entity("ThrAPI.Models.Login.ClaimsTypeModel", b =>
                {
                    b.Navigation("ListClaimsOfUser");
                });
#pragma warning restore 612, 618
        }
    }
}
