﻿// <auto-generated />
using System;
using BraidoRental.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BraidoRental.Services.Infrastructure.Migrations
{
    [DbContext(typeof(BraidoRentalContext))]
    partial class BraidoRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BraidoRental.Services.Estoque.Domain.Entities.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDisponivel")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDisponivel")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnName("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnName("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnName("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("BraidoRental.Services.Faturamento.Domain.Entities.CarroFaturamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarroLocacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotalLocacao")
                        .HasColumnName("ValorTotalLocacao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarroLocacaoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("CarroFaturamento");
                });

            modelBuilder.Entity("BraidoRental.Services.Locadora.Domain.Entities.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CarroComCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CarroComCliente")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("CarroLocacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarroLocacaoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("BraidoRental.Services.Locadora.Domain.Entities.CarroLocacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarroId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDiario")
                        .HasColumnName("ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.ToTable("CarroLocacao");
                });

            modelBuilder.Entity("BraidoRental.Services.Locadora.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BraidoRental.Services.Faturamento.Domain.Entities.CarroFaturamento", b =>
                {
                    b.HasOne("BraidoRental.Services.Locadora.Domain.Entities.CarroLocacao", "CarroLocacao")
                        .WithMany()
                        .HasForeignKey("CarroLocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BraidoRental.Services.Locadora.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BraidoRental.Services.Locadora.Domain.Entities.Agendamento", b =>
                {
                    b.HasOne("BraidoRental.Services.Locadora.Domain.Entities.CarroLocacao", "CarroLocacao")
                        .WithMany("Agendamentos")
                        .HasForeignKey("CarroLocacaoId");

                    b.HasOne("BraidoRental.Services.Locadora.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("BraidoRental.Services.Locadora.Domain.Entities.CarroLocacao", b =>
                {
                    b.HasOne("BraidoRental.Services.Estoque.Domain.Entities.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");
                });
#pragma warning restore 612, 618
        }
    }
}
