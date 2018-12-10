﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeleHelp.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo");

                    b.Property<string>("Codclie");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<int>("EstadoCivil");

                    b.Property<int?>("Genero");

                    b.Property<string>("InscricaoEstadual")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Rg")
                        .HasColumnType("varchar(12)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
