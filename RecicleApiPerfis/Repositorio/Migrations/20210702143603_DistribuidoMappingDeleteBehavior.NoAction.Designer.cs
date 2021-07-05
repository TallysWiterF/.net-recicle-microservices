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
    [Migration("20210702143603_DistribuidoMappingDeleteBehavior.NoAction")]
    partial class DistribuidoMappingDeleteBehaviorNoAction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Coletor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DATACRIACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<Guid>("IdUser")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDUSER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("Nome");

                    b.ToTable("COLETOR");
                });

            modelBuilder.Entity("Dominio.Entidades.Distribuidor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DATACRIACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<Guid?>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEndereco")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDENDERECO");

                    b.Property<Guid>("IdUser")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDUSER");

                    b.Property<string>("Latitude")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LATITUDE");

                    b.Property<string>("Longitude")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LONGITUDE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("NumeroResidencia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("NUMERORESIDENCIA");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdUser");

                    b.HasIndex("Nome");

                    b.ToTable("DISTRIBUIDOR");
                });

            modelBuilder.Entity("Dominio.Entidades.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("RUA");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.HasIndex("Cep");

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("Dominio.Entidades.Distribuidor", b =>
                {
                    b.HasOne("Dominio.Entidades.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("Dominio.Entidades.Endereco", null)
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
