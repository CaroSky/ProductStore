﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductStore.Data;

#nullable disable

namespace ProductStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231016162320_AddNewProducts")]
    partial class AddNewProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductStore.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Verktøy"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Dagligvarer"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Kjøretøy"
                        });
                });

            modelBuilder.Entity("ProductStore.Models.Entities.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1,
                            Name = "Manufacturer 1"
                        },
                        new
                        {
                            ManufacturerId = 2,
                            Name = "Manufacturer 2"
                        });
                });

            modelBuilder.Entity("ProductStore.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ManufacturerId = 1,
                            Name = "Hammer",
                            Price = 121.50m
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            ManufacturerId = 1,
                            Name = "Vinkelsliper",
                            Price = 1520.00m
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ManufacturerId = 2,
                            Name = "Volvo XC90",
                            Price = 990000m
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3,
                            ManufacturerId = 2,
                            Name = "Volvo XC60",
                            Price = 620000m
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            ManufacturerId = 1,
                            Name = "Brød",
                            Price = 25.50m
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            ManufacturerId = 2,
                            Name = "Produkt 1",
                            Price = 99.99m
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 2,
                            ManufacturerId = 1,
                            Name = "Produkt 2",
                            Price = 49.99m
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3,
                            ManufacturerId = 2,
                            Name = "Produkt 3",
                            Price = 199.99m
                        });
                });

            modelBuilder.Entity("ProductStore.Models.Entities.Product", b =>
                {
                    b.HasOne("ProductStore.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductStore.Models.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("ProductStore.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductStore.Models.Entities.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
