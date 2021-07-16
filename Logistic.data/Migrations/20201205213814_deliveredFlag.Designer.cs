﻿// <auto-generated />
using System;
using Logistic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logistic.Data.Migrations
{
    [DbContext(typeof(LogisticDbContext))]
    [Migration("20201205213814_deliveredFlag")]
    partial class deliveredFlag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Logistic.Data.Entities.Depot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationX")
                        .HasColumnType("int");

                    b.Property<int>("LocationY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Depots");
                });

            modelBuilder.Entity("Logistic.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Delivered")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<string>("TransportFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransportFromX")
                        .HasColumnType("int");

                    b.Property<int>("TransportFromY")
                        .HasColumnType("int");

                    b.Property<string>("TransportTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransportToX")
                        .HasColumnType("int");

                    b.Property<int>("TransportToY")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Logistic.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Logistic.Data.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepotId")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxSize")
                        .HasColumnType("float");

                    b.Property<double>("MaxWeight")
                        .HasColumnType("float");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DepotId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Logistic.Data.Entities.Order", b =>
                {
                    b.HasOne("Logistic.Data.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logistic.Data.Entities.Vehicle", "Vehicle")
                        .WithMany("Orders")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("Logistic.Data.Entities.Vehicle", b =>
                {
                    b.HasOne("Logistic.Data.Entities.Depot", "Depot")
                        .WithMany("Vehicles")
                        .HasForeignKey("DepotId");
                });
#pragma warning restore 612, 618
        }
    }
}