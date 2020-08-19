﻿// <auto-generated />
using System;
using AnagramSolver.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    [DbContext(typeof(AnagramContext))]
    [Migration("20200817070347_AddValidations")]
    partial class AddValidations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("AnagramSolver.Models.CachedWordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SearchWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserLogEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserLogEntityId");

                    b.ToTable("CachedWordEntities");
                });

            modelBuilder.Entity("AnagramSolver.Models.UserLogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserLogEntities");
                });

            modelBuilder.Entity("AnagramSolver.Models.WordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CachedWordEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CachedWordEntityId");

                    b.ToTable("WordEntities");
                });

            modelBuilder.Entity("AnagramSolver.Models.CachedWordEntity", b =>
                {
                    b.HasOne("AnagramSolver.Models.UserLogEntity", null)
                        .WithMany("CachedWordEntity")
                        .HasForeignKey("UserLogEntityId");
                });

            modelBuilder.Entity("AnagramSolver.Models.WordEntity", b =>
                {
                    b.HasOne("AnagramSolver.Models.CachedWordEntity", null)
                        .WithMany("WordEntity")
                        .HasForeignKey("CachedWordEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
