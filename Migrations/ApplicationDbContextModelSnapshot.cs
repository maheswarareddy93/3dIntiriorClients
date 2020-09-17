﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3dIntiriorClients.Models;

namespace _3dIntiriorClients.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_3dIntiriorClients.Models.AdminsInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<sbyte?>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<string>("Mobile")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("AdminsInfo");
                });

            modelBuilder.Entity("_3dIntiriorClients.Models.CustomerInfo", b =>
                {
                    b.Property<int>("Customerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Customername")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Emailid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<sbyte?>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<string>("LeadType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Mobileno")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Customerid");

                    b.ToTable("customerInfo");
                });

            modelBuilder.Entity("_3dIntiriorClients.Models.GallaryImages", b =>
                {
                    b.Property<int>("GId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Images")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoomTypeID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UpdatedDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("GId");

                    b.ToTable("GallaryImages");
                });

            modelBuilder.Entity("_3dIntiriorClients.Models.ProjectDataInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Finalimage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Projectname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Referenceimages")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UnitSize")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UnitType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("cuuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ProjectDataInfo");
                });

            modelBuilder.Entity("_3dIntiriorClients.Models.PropertyTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("_3dIntiriorClients.Models.RoomTypes", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("RoomId");

                    b.ToTable("RoomTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
