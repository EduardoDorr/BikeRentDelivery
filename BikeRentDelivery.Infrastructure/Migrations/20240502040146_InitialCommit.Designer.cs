﻿// <auto-generated />
using System;
using BikeRentDelivery.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BikeRentDelivery.Infrastructure.Migrations
{
    [DbContext(typeof(BikeRentDeliveryDbContext))]
    [Migration("20240502040146_InitialCommit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BikeRentDelivery.Common.Persistence.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Error")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Bikes.Bike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Notifications.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("RentalId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasPrecision(6, 2)
                        .HasColumnType("numeric(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("RentalId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Rentals.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("AdditionalCost")
                        .HasPrecision(6, 2)
                        .HasColumnType("numeric(6,2)");

                    b.Property<Guid>("BikeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("LateFeeCost")
                        .HasPrecision(6, 2)
                        .HasColumnType("numeric(6,2)");

                    b.Property<int>("Plan")
                        .HasColumnType("integer");

                    b.Property<decimal>("RentalCost")
                        .HasPrecision(7, 2)
                        .HasColumnType("numeric(7,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("UserId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Bikes.Bike", b =>
                {
                    b.OwnsOne("BikeRentDelivery.Common.ValueObjects.LicensePlate", "LicensePlate", b1 =>
                        {
                            b1.Property<Guid>("BikeId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(7)
                                .HasColumnType("character varying(7)")
                                .HasColumnName("LicensePlate");

                            b1.HasKey("BikeId");

                            b1.HasIndex("Number")
                                .IsUnique();

                            b1.ToTable("Bikes");

                            b1.WithOwner()
                                .HasForeignKey("BikeId");
                        });

                    b.Navigation("LicensePlate")
                        .IsRequired();
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Notifications.Notification", b =>
                {
                    b.HasOne("BikeRentDelivery.Domain.Orders.Order", "Order")
                        .WithMany("Notifications")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeRentDelivery.Domain.Users.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Orders.Order", b =>
                {
                    b.HasOne("BikeRentDelivery.Domain.Rentals.Rental", "Rental")
                        .WithMany("Orders")
                        .HasForeignKey("RentalId");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Rentals.Rental", b =>
                {
                    b.HasOne("BikeRentDelivery.Domain.Bikes.Bike", "Bike")
                        .WithMany("Rentals")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeRentDelivery.Domain.Users.User", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Users.User", b =>
                {
                    b.OwnsOne("BikeRentDelivery.Common.ValueObjects.Cnh", "Cnh", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Image")
                                .HasColumnType("text")
                                .HasColumnName("CnhImage");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("character varying(11)")
                                .HasColumnName("CnhNumber");

                            b1.Property<int>("Type")
                                .HasColumnType("integer")
                                .HasColumnName("CnhType");

                            b1.HasKey("UserId");

                            b1.HasIndex("Number")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("BikeRentDelivery.Common.ValueObjects.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("character varying(14)")
                                .HasColumnName("Cnpj");

                            b1.HasKey("UserId");

                            b1.HasIndex("Number")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("BikeRentDelivery.Common.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.HasIndex("Address")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("BikeRentDelivery.Common.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Cnh")
                        .IsRequired();

                    b.Navigation("Cnpj")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Bikes.Bike", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Orders.Order", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Rentals.Rental", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BikeRentDelivery.Domain.Users.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
