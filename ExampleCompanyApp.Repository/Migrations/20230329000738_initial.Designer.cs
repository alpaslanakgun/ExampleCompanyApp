﻿// <auto-generated />
using System;
using ExampleCompanyApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExampleCompanyApp.Repository.Migrations
{
    [DbContext(typeof(ExampleCompanyDbContext))]
    [Migration("20230329000738_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExampleCompanyApp.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "TV"
                        });
                });

            modelBuilder.Entity("ExampleCompanyApp.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3078),
                            Name = "Apple Iphone 14",
                            Price = 45000m,
                            Stock = 250
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3089),
                            Name = "Apple Iphone 13",
                            Price = 26000m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3090),
                            Name = "Apple Iphone 12",
                            Price = 22000m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3091),
                            Name = "Dell G15",
                            Price = 35000m,
                            Stock = 450
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3094),
                            Name = "Toshiba SATELLITE",
                            Price = 1000m,
                            Stock = 150
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3094),
                            Name = "Sony Bravia",
                            Price = 65000m,
                            Stock = 215
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 3, 29, 3, 7, 38, 534, DateTimeKind.Local).AddTicks(3097),
                            Name = "Samsung OLED",
                            Price = 25000m,
                            Stock = 173
                        });
                });

            modelBuilder.Entity("ExampleCompanyApp.Core.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Blue",
                            Height = 150,
                            ProductId = 1,
                            Width = 150
                        },
                        new
                        {
                            Id = 2,
                            Color = "Black",
                            Height = 300,
                            ProductId = 2,
                            Width = 500
                        });
                });

            modelBuilder.Entity("ExampleCompanyApp.Core.Product", b =>
                {
                    b.HasOne("ExampleCompanyApp.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ExampleCompanyApp.Core.ProductFeature", b =>
                {
                    b.HasOne("ExampleCompanyApp.Core.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("ExampleCompanyApp.Core.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ExampleCompanyApp.Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ExampleCompanyApp.Core.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });
#pragma warning restore 612, 618
        }
    }
}
