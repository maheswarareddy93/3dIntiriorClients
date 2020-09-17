﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3dIntiriorClients.Models;

namespace _3dIntiriorClients.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200904092155_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_3dIntiriorClients.Models.CustomerInfo", b =>
                {
                    b.Property<int>("Customerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

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
#pragma warning restore 612, 618
        }
    }
}
