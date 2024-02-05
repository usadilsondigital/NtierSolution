﻿// <auto-generated />
using System;
using DataAccessTier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessTier.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210324052101_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityTier.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Contactname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContacttypeId")
                        .HasColumnType("int");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("ContacttypeId");

                    b.ToTable("contact");
                });

            modelBuilder.Entity("EntityTier.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Contactname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContacttypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBooking")
                        .HasColumnType("datetime2")
                        .HasComment("needed according to pictures");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit")
                        .HasComment("needed according to pictures");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasComment("needed according to pictures");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("ContacttypeId");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("EntityTier.Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("types");
                });

            modelBuilder.Entity("EntityTier.Contact", b =>
                {
                    b.HasOne("EntityTier.Types", "Contacttype")
                        .WithMany()
                        .HasForeignKey("ContacttypeId");

                    b.Navigation("Contacttype");
                });

            modelBuilder.Entity("EntityTier.Reservation", b =>
                {
                    b.HasOne("EntityTier.Contact", null)
                        .WithMany("Reservations")
                        .HasForeignKey("ContactId");

                    b.HasOne("EntityTier.Types", "Contacttype")
                        .WithMany()
                        .HasForeignKey("ContacttypeId");

                    b.Navigation("Contacttype");
                });

            modelBuilder.Entity("EntityTier.Contact", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}