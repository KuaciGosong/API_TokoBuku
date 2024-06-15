﻿// <auto-generated />
using System;
using API_TokoBuku.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_TokoBuku.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240615144359_DB_TokoBuku")]
    partial class DB_TokoBuku
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_TokoBuku.Models.Buku", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Harga_Satuan")
                        .HasColumnType("int");

                    b.Property<string>("Judul_Buku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Penulis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bukus");
                });

            modelBuilder.Entity("API_TokoBuku.Models.Pelanggan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nama_Pelanggan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pelanggans");
                });

            modelBuilder.Entity("API_TokoBuku.Models.Pembelian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BukuID")
                        .HasColumnType("int");

                    b.Property<int>("Jumlah_Beli")
                        .HasColumnType("int");

                    b.Property<int>("PelangganID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Tanggal_Pembelian")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BukuID");

                    b.HasIndex("PelangganID");

                    b.ToTable("Pembelians");
                });

            modelBuilder.Entity("API_TokoBuku.Models.Pembelian", b =>
                {
                    b.HasOne("API_TokoBuku.Models.Buku", "Buku")
                        .WithMany("pembelians")
                        .HasForeignKey("BukuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_TokoBuku.Models.Pelanggan", "Pelanggan")
                        .WithMany("pembelians")
                        .HasForeignKey("PelangganID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buku");

                    b.Navigation("Pelanggan");
                });

            modelBuilder.Entity("API_TokoBuku.Models.Buku", b =>
                {
                    b.Navigation("pembelians");
                });

            modelBuilder.Entity("API_TokoBuku.Models.Pelanggan", b =>
                {
                    b.Navigation("pembelians");
                });
#pragma warning restore 612, 618
        }
    }
}