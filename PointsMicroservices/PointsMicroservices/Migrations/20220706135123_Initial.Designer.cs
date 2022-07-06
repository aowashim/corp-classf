﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointsMicroservices.Database;

namespace PointsMicroservices.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220706135123_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PointsMicroservices.Database.Entities.Point", b =>
                {
                    b.Property<int>("Point_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Emp_Id")
                        .HasColumnType("int");

                    b.Property<int>("Emp_Point")
                        .HasColumnType("int");

                    b.HasKey("Point_Id");

                    b.ToTable("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
