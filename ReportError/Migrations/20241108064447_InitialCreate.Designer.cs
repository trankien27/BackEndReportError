﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReportError;

#nullable disable

namespace ReportError.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241108064447_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReportError.Error", b =>
                {
                    b.Property<string>("ErrorId")
                        .HasColumnType("text");

                    b.Property<string>("DescriptionError")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ErrorChecker")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ErrorDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssueReporter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RootCause")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Shop")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeReport")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ErrorId");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("ReportError.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
