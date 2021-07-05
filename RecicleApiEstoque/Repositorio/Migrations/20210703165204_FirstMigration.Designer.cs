﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio.Contexto;

namespace Repositorio.Migrations
{
    [DbContext(typeof(ContextoEntity))]
    [Migration("20210703165204_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Estoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DATAATUALIZACAO");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Quantidade")
                        .HasMaxLength(100)
                        .HasColumnType("numeric(38,17)")
                        .HasColumnName("QUANTIDADE");

                    b.Property<string>("TipoQuantidade")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TIPOQUANTIDADE");

                    b.HasKey("Id");

                    b.ToTable("ESTOQUE");
                });

            modelBuilder.Entity("Dominio.Entidades.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdDistribuidor")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDDISTRIBUIDOR");

                    b.Property<Guid>("IdEstoque")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDESTOQUE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("TipoMaterial")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TIPOMATERIAL");

                    b.HasKey("Id");

                    b.HasIndex("IdDistribuidor");

                    b.HasIndex("IdEstoque")
                        .IsUnique();

                    b.ToTable("ITEM");
                });

            modelBuilder.Entity("Dominio.Entidades.Item", b =>
                {
                    b.HasOne("Dominio.Entidades.Estoque", "Estoque")
                        .WithOne("Item")
                        .HasForeignKey("Dominio.Entidades.Item", "IdEstoque")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("Dominio.Entidades.Estoque", b =>
                {
                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
