﻿// <auto-generated />
using System;
using IFExperiment.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IFExperiment.Infra.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.AreaExperimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataCadastrado");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<int>("Excluido");

                    b.Property<Guid>("ExperimentroId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentroId")
                        .IsUnique();

                    b.ToTable("AreasExperimentos");
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.Bloco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AreaExperimentoId");

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataCadastrado");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<int>("Excluido");

                    b.Property<string>("NomeBloco")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("AreaExperimentoId");

                    b.ToTable("Blocos");
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.BlocoTratamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BlocoId");

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataAvaliacao");

                    b.Property<DateTime>("DataCadastrado");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<int>("Excluido");

                    b.Property<string>("NomeParcela")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<Guid>("TratamentoId");

                    b.HasKey("Id");

                    b.HasIndex("BlocoId");

                    b.HasIndex("TratamentoId");

                    b.ToTable("BlocosTratamentos");
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.Experimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataCadastrado");

                    b.Property<DateTime>("DataConclusao");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<DateTime>("DataInicio");

                    b.Property<int>("Excluido");

                    b.Property<int>("QtdRepeticao");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Experimentos");
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.ExperimentoTramento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataCadastrado");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<int>("Excluido");

                    b.Property<Guid>("ExperimentoId");

                    b.Property<int>("Qtd");

                    b.Property<Guid>("TratamentoId");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentoId");

                    b.HasIndex("TratamentoId")
                        .IsUnique();

                    b.ToTable("ExperimentosTratamentos");
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.Tratamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataCadastrado");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<int>("Excluido");

                    b.Property<Guid>("ExperimentoTratamentoId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Tramentos");
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.AreaExperimento", b =>
                {
                    b.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Experimento", "Experimentro")
                        .WithOne("AreaExperimento")
                        .HasForeignKey("IFExperiment.Domain.ExperimentContext.Entites.AreaExperimento", "ExperimentroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.Bloco", b =>
                {
                    b.HasOne("IFExperiment.Domain.ExperimentContext.Entites.AreaExperimento", "AreaExperimento")
                        .WithMany("Blocos")
                        .HasForeignKey("AreaExperimentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.BlocoTratamento", b =>
                {
                    b.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Bloco", "Bloco")
                        .WithMany("BlocoTratamentos")
                        .HasForeignKey("BlocoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Tratamento", "Tratamento")
                        .WithMany()
                        .HasForeignKey("TratamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.Experimento", b =>
                {
                    b.OwnsOne("IFExperiment.Domain.ExperimentContext.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("ExperimentoId");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnName("Nome")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Experimentos","public");

                            b1.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Experimento")
                                .WithOne("Nome")
                                .HasForeignKey("IFExperiment.Domain.ExperimentContext.ValueObjects.Nome", "ExperimentoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.ExperimentoTramento", b =>
                {
                    b.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Experimento", "Experimento")
                        .WithMany("ExperimentoTramentos")
                        .HasForeignKey("ExperimentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Tratamento", "Tratamento")
                        .WithOne("ExperimentoTramento")
                        .HasForeignKey("IFExperiment.Domain.ExperimentContext.Entites.ExperimentoTramento", "TratamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IFExperiment.Domain.ExperimentContext.Entites.Tratamento", b =>
                {
                    b.OwnsOne("IFExperiment.Domain.ExperimentContext.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("TratamentoId");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnName("Nome")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Tramentos","public");

                            b1.HasOne("IFExperiment.Domain.ExperimentContext.Entites.Tratamento")
                                .WithOne("Nome")
                                .HasForeignKey("IFExperiment.Domain.ExperimentContext.ValueObjects.Nome", "TratamentoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
