﻿// <auto-generated />
using System;
using DEMO1.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEMO1.Migrations
{
    [DbContext(typeof(TrainerTestDBContext))]
    [Migration("20231021030235_CategoriesDbCreateChangeTypeDate")]
    partial class CategoriesDbCreateChangeTypeDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DEMO1.DBContext.TrainerTestCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Description");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("NameCategory");

                    b.Property<int>("Status")
                        .HasColumnType("Integer")
                        .HasColumnName("Status");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Icon");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
