﻿// <auto-generated />
using System;
using EnemApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnemApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200115172339_AddNomeConcurso")]
    partial class AddNomeConcurso
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnemApp.API.Models.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprovado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("aprovado")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("cidade")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Nota")
                        .HasColumnName("nota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("EnemApp.API.Models.CandidatoConcurso", b =>
                {
                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("ConcursoId")
                        .HasColumnType("int");

                    b.HasKey("CandidatoId", "ConcursoId");

                    b.HasIndex("ConcursoId");

                    b.ToTable("CandidatoConcurso");
                });

            modelBuilder.Entity("EnemApp.API.Models.Concurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataRealizacao")
                        .HasColumnName("data_realizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("NumeroVagas")
                        .HasColumnName("numero_vagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Concursos");
                });

            modelBuilder.Entity("EnemApp.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("EnemApp.API.Models.CandidatoConcurso", b =>
                {
                    b.HasOne("EnemApp.API.Models.Candidato", "Candidato")
                        .WithMany("CandidatosConcursos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnemApp.API.Models.Concurso", "Concurso")
                        .WithMany("CandidatosConcursos")
                        .HasForeignKey("ConcursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
