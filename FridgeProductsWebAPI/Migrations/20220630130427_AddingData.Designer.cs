﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FridgeProductsWebAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220630130427_AddingData")]
    partial class AddingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FridgeProductsWebAPI.Models.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FridgeId");

                    b.Property<Guid>("FridgeModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FridgeModelId");

                    b.ToTable("fridge");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            FridgeModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Atlant",
                            OwnerName = "Kirill"
                        },
                        new
                        {
                            Id = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                            FridgeModelId = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Cool",
                            OwnerName = "Michael"
                        });
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FridgeModelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("fridge_model");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Model1",
                            Year = 1990
                        },
                        new
                        {
                            Id = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Model2",
                            Year = 1994
                        });
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.FridgeProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FridgeProductId");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId");

                    b.ToTable("fridge_products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            FridgeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Quantity = 12
                        },
                        new
                        {
                            Id = new Guid("96dba8c0-d178-41e7-938c-ed49778fb52a"),
                            FridgeId = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                            ProductId = new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            DefaultQuantity = 12,
                            Name = "Banana"
                        },
                        new
                        {
                            Id = new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"),
                            DefaultQuantity = 20,
                            Name = "Strawberry"
                        });
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.Fridge", b =>
                {
                    b.HasOne("FridgeProductsWebAPI.Models.FridgeModel", "FridgeModel")
                        .WithMany("Fridges")
                        .HasForeignKey("FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.FridgeProduct", b =>
                {
                    b.HasOne("FridgeProductsWebAPI.Models.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeProductsWebAPI.Models.Product", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.FridgeModel", b =>
                {
                    b.Navigation("Fridges");
                });

            modelBuilder.Entity("FridgeProductsWebAPI.Models.Product", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
