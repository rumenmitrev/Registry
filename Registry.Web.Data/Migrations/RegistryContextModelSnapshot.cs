﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registry.Web.Data;

namespace Registry.Web.Data.Migrations
{
    [DbContext(typeof(RegistryContext))]
    partial class RegistryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Registry.Web.Data.Models.Batch", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("DatasetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Token");

                    b.HasIndex("DatasetId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Dataset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("InternalRef")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ObjectsCount")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationSlug")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationSlug");

                    b.HasIndex("Slug");

                    b.ToTable("Datasets");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.DownloadPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DatasetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Paths")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DatasetId");

                    b.ToTable("DownloadPackages");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BatchToken")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BatchToken");

                    b.ToTable("Entry");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Organization", b =>
                {
                    b.Property<string>("Slug")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Slug");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Batch", b =>
                {
                    b.HasOne("Registry.Web.Data.Models.Dataset", "Dataset")
                        .WithMany("Batches")
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dataset");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Dataset", b =>
                {
                    b.HasOne("Registry.Web.Data.Models.Organization", "Organization")
                        .WithMany("Datasets")
                        .HasForeignKey("OrganizationSlug")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.DownloadPackage", b =>
                {
                    b.HasOne("Registry.Web.Data.Models.Dataset", "Dataset")
                        .WithMany("DownloadPackages")
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dataset");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Entry", b =>
                {
                    b.HasOne("Registry.Web.Data.Models.Batch", "Batch")
                        .WithMany("Entries")
                        .HasForeignKey("BatchToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Batch", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Dataset", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("DownloadPackages");
                });

            modelBuilder.Entity("Registry.Web.Data.Models.Organization", b =>
                {
                    b.Navigation("Datasets");
                });
#pragma warning restore 612, 618
        }
    }
}
