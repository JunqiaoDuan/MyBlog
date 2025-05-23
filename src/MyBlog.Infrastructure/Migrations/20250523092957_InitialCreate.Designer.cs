﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Infrastructure.Db.EF;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    [DbContext(typeof(MyBlogContext))]
    [Migration("20250523092957_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.36");

            modelBuilder.Entity("MyBlog.Service.Entities.ProjectAgregate.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsValid")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ModBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("ModDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReasonOfInvalid")
                        .HasColumnType("TEXT");

                    b.Property<int>("SortNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlDemo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlGitHub")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
