﻿// <auto-generated />
using System;
using LivroEC_V2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LivroEC_V2.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20240920191859_PedidoDetalhes")]
    partial class PedidoDetalhes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LivroEC_V2.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarrinhoCompraItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrinhoCompraItemId"), 1L, 1);

                    b.Property<string>("CarrinhoCompraId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoCompraItemId");

                    b.HasIndex("LivroId");

                    b.ToTable("CarinhoCompraItens");
                });

            modelBuilder.Entity("LivroEC_V2.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LivroEC_V2.Models.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"), 1L, 1);

                    b.Property<string>("CaminhoImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoCurta")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("EmEstoque")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLivroPreferido")
                        .HasColumnType("bit");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LivroId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("LivroEC_V2.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Endereco1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Endereco2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("PedidoEntregueEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PedidoEnviado")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PedidoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("TotalItensPedido")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("LivroEC_V2.Models.PedidoDetalhe", b =>
                {
                    b.Property<int>("PedidoDetalheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoDetalheId"), 1L, 1);

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("PedidoDetalheId");

                    b.HasIndex("LivroId");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoDetalhes");
                });

            modelBuilder.Entity("LivroEC_V2.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("LivroEC_V2.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("LivroEC_V2.Models.Livro", b =>
                {
                    b.HasOne("LivroEC_V2.Models.Categoria", "Categorias")
                        .WithMany("Livros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("LivroEC_V2.Models.PedidoDetalhe", b =>
                {
                    b.HasOne("LivroEC_V2.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivroEC_V2.Models.Pedido", "Pedido")
                        .WithMany("PedidosItens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("LivroEC_V2.Models.Categoria", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("LivroEC_V2.Models.Pedido", b =>
                {
                    b.Navigation("PedidosItens");
                });
#pragma warning restore 612, 618
        }
    }
}