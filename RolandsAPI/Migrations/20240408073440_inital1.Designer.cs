﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RolandsAPI.Data;

#nullable disable

namespace RolandsAPI.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240408073440_inital1")]
    partial class inital1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RolandsAPI.Models.Dzivoklis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("DzivojamaPlatiba")
                        .HasColumnType("real");

                    b.Property<int>("IedzivotajuSkaits")
                        .HasColumnType("int");

                    b.Property<int>("IstabuSkaits")
                        .HasColumnType("int");

                    b.Property<int>("MajaId")
                        .HasColumnType("int");

                    b.Property<int>("Numurs")
                        .HasColumnType("int");

                    b.Property<float>("PilnaPlatiba")
                        .HasColumnType("real");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stavs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dzivokli");
                });

            modelBuilder.Entity("RolandsAPI.Models.Iedzivotajs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DzimsanasDatums")
                        .HasColumnType("datetime2");

                    b.Property<int>("DzivoklisId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("PersonasKods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefons")
                        .HasColumnType("int");

                    b.Property<string>("Uzvards")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vards")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Iedzivotaji");
                });

            modelBuilder.Entity("RolandsAPI.Models.Maja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Iela")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numurs")
                        .HasColumnType("int");

                    b.Property<string>("PastaIndekss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pilseta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valsts")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Majas");
                });
#pragma warning restore 612, 618
        }
    }
}
