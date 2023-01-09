﻿// <auto-generated />
#pragma warning disable CS8981
using System;
using BuberDinner.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuberDinner.Persistence.Migrations
{
    [DbContext(typeof(BuberDinnerDbContext))]
    [Migration("20230109132842_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BuberDinner.Domain.Aggregates.MenuAggregate.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedDateTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BuberDinner.Domain.Aggregates.MenuAggregate.Menu", b =>
                {
                    b.OwnsMany("BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Aggregates.MenuAggregate.Entities.MenuSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("MenuSectionId");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("Id", "MenuId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("BuberDinner.Domain.Aggregates.MenuAggregate.Entities.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid")
                                        .HasColumnName("MenuItemId");

                                    b2.Property<Guid>("MenuSectionId")
                                        .HasColumnType("uuid");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("Id", "MenuSectionId", "MenuId");

                                    b2.HasIndex("MenuSectionId", "MenuId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuSectionId", "MenuId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsOne("BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<float>("Value")
                                .HasColumnType("real");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("ReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}