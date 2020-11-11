﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petshop.Server;

namespace Petshop.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PetshopOA.Shared.Autorizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CadastrarAnimal")
                        .HasColumnType("int");

                    b.Property<int>("CadastrarContraatos")
                        .HasColumnType("int");

                    b.Property<int>("CadastrarFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("CadastrarPetshop")
                        .HasColumnType("int");

                    b.Property<int>("CadastrarServico")
                        .HasColumnType("int");

                    b.Property<int>("EditarAnimal")
                        .HasColumnType("int");

                    b.Property<int>("ExcluirAnimal")
                        .HasColumnType("int");

                    b.Property<int>("VerAnimal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Autorizacao");
                });

            modelBuilder.Entity("PetshopOA.Shared.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Numeroidentificacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PetshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetshopId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PetshopOA.Shared.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("Numerocontrato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId")
                        .IsUnique();

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("PetshopOA.Shared.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Numeroidentificacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("PetshopOA.Shared.Petshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Petshops");
                });

            modelBuilder.Entity("PetshopOA.Shared.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("PetshopOA.Shared.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorizacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AutorizacaoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PetshopOA.Shared.Cliente", b =>
                {
                    b.HasOne("PetshopOA.Shared.Petshop", "Petshop")
                        .WithMany("Clientes")
                        .HasForeignKey("PetshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetshopOA.Shared.Contrato", b =>
                {
                    b.HasOne("PetshopOA.Shared.Funcionario", "Funcionario")
                        .WithOne("Contrato")
                        .HasForeignKey("PetshopOA.Shared.Contrato", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetshopOA.Shared.Servico", b =>
                {
                    b.HasOne("PetshopOA.Shared.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetshopOA.Shared.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetshopOA.Shared.Usuario", b =>
                {
                    b.HasOne("PetshopOA.Shared.Autorizacao", "Autorizacao")
                        .WithMany()
                        .HasForeignKey("AutorizacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
