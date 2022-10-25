﻿// <auto-generated />
using System;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(TimekeepingContext))]
    [Migration("20221025073035_TimeCardMany")]
    partial class TimeCardMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("App.ClassLib.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("App.ClassLib.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("App.ClassLib.Project", b =>
                {
                    b.OwnsMany("App.ClassLib.TimeCard", "Hours", b1 =>
                        {
                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT")
                                .HasColumnName("TimeCardId");

                            b1.Property<DateTimeOffset>("Date")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("DriverId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("Hours")
                                .HasColumnType("REAL");

                            b1.HasKey("ProjectId", "Id");

                            b1.ToTable("TimeCard");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("Hours");
                });
#pragma warning restore 612, 618
        }
    }
}