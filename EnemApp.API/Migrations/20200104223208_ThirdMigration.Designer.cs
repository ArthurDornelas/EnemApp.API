﻿// <auto-generated />
using EnemApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnemApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200104223208_ThirdMigration")]
    partial class ThirdMigration
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
                        .HasColumnName("aprovado")
                        .HasColumnType("bit");

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
#pragma warning restore 612, 618
        }
    }
}
