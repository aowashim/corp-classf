﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OffersMicroservices.Database;

namespace OffersMicroservices.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220712113609_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("Offer_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Office_Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points_Gained")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Emp_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Engaged_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("N_Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Offer_Category", b =>
                {
                    b.Property<int>("Cateory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cateory_Id");

                    b.ToTable("Offer_Category");
                });

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Comment", b =>
                {
                    b.HasOne("OffersMicroservices.Database.Entities.Offer", null)
                        .WithMany("CommentList")
                        .HasForeignKey("OfferId");
                });

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Offer", b =>
                {
                    b.HasOne("OffersMicroservices.Database.Entities.Offer_Category", "Offer_Category")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer_Category");
                });

            modelBuilder.Entity("OffersMicroservices.Database.Entities.Offer", b =>
                {
                    b.Navigation("CommentList");
                });
#pragma warning restore 612, 618
        }
    }
}
