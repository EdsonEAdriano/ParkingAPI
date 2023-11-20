﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingAPI.Data;

#nullable disable

namespace ParkingAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231120024447_alterTableControlPrice")]
    partial class alterTableControlPrice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingAPI.Models.Company", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("cnpj")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qtyCarsSpaces")
                        .HasColumnType("int");

                    b.Property<int>("qtyMotorcycleSpaces")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ParkingAPI.Models.Control", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("companyID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("exitDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("priceID")
                        .HasColumnType("smallint");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("vehicleID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("companyID");

                    b.HasIndex("priceID");

                    b.HasIndex("vehicleID");

                    b.ToTable("Controls");
                });

            modelBuilder.Entity("ParkingAPI.Models.Prices", b =>
                {
                    b.Property<short>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("id"));

                    b.Property<short>("hours")
                        .HasColumnType("smallint");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("ParkingAPI.Models.Vehicle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParkingAPI.Models.Control", b =>
                {
                    b.HasOne("ParkingAPI.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("companyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingAPI.Models.Prices", "price")
                        .WithMany()
                        .HasForeignKey("priceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingAPI.Models.Vehicle", "vehicle")
                        .WithMany()
                        .HasForeignKey("vehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");

                    b.Navigation("price");

                    b.Navigation("vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
