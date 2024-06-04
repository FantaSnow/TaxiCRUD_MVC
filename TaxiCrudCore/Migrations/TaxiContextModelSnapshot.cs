﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiCrudCore.Context;

#nullable disable

namespace TaxiCrudCore.Migrations
{
    [DbContext(typeof(TaxiContext))]
    partial class TaxiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxiCrudCore.Entities.Auto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<Guid>("RoadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoadId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.Road", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityEndId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityStartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserDriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityEndId");

                    b.HasIndex("CityStartId");

                    b.HasIndex("UserDriverId");

                    b.HasIndex("UserOrderId");

                    b.ToTable("Roads");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.Order", b =>
                {
                    b.HasOne("TaxiCrudCore.Entities.Road", "Road")
                        .WithMany()
                        .HasForeignKey("RoadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiCrudCore.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Road");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TaxiCrudCore.Entities.Road", b =>
                {
                    b.HasOne("TaxiCrudCore.Entities.City", "CityEnd")
                        .WithMany()
                        .HasForeignKey("CityEndId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TaxiCrudCore.Entities.City", "CityStart")
                        .WithMany()
                        .HasForeignKey("CityStartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TaxiCrudCore.Entities.User", "UserDriver")
                        .WithMany()
                        .HasForeignKey("UserDriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TaxiCrudCore.Entities.User", "UserOrder")
                        .WithMany()
                        .HasForeignKey("UserOrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CityEnd");

                    b.Navigation("CityStart");

                    b.Navigation("UserDriver");

                    b.Navigation("UserOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
