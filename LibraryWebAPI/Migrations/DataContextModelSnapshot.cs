﻿// <auto-generated />
using System;
using LibraryWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryWebAPI.Model.Books", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Author")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("tblBooks", (string)null);
                });

            modelBuilder.Entity("LibraryWebAPI.Model.IssueBook", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("BookId")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("StuId")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("UserId")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StatusId");

                    b.HasIndex("StuId");

                    b.HasIndex("UserId");

                    b.ToTable("tblIssueBook", (string)null);
                });

            modelBuilder.Entity("LibraryWebAPI.Model.ReturnBook", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("BookId")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StuId")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("UserId")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StuId");

                    b.HasIndex("UserId");

                    b.ToTable("tblReturnBook", (string)null);
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("tblStatus", (string)null);
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Students", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<byte?>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Contact")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("tblStudents", (string)null);
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<byte?>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Contact")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblUsers", (string)null);
                });

            modelBuilder.Entity("LibraryWebAPI.Model.IssueBook", b =>
                {
                    b.HasOne("LibraryWebAPI.Model.Books", "Books")
                        .WithMany("IssueBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LibraryWebAPI.Model.Status", "Status")
                        .WithMany("IssueBooks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LibraryWebAPI.Model.Students", "Students")
                        .WithMany("IssueBooks")
                        .HasForeignKey("StuId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LibraryWebAPI.Model.Users", "Users")
                        .WithMany("IssueBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Books");

                    b.Navigation("Status");

                    b.Navigation("Students");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("LibraryWebAPI.Model.ReturnBook", b =>
                {
                    b.HasOne("LibraryWebAPI.Model.Books", "Books")
                        .WithMany("ReturnBook")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LibraryWebAPI.Model.Students", "Students")
                        .WithMany("ReturnBook")
                        .HasForeignKey("StuId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LibraryWebAPI.Model.Users", "Users")
                        .WithMany("ReturnBook")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Books");

                    b.Navigation("Students");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Books", b =>
                {
                    b.Navigation("IssueBooks");

                    b.Navigation("ReturnBook");
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Status", b =>
                {
                    b.Navigation("IssueBooks");
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Students", b =>
                {
                    b.Navigation("IssueBooks");

                    b.Navigation("ReturnBook");
                });

            modelBuilder.Entity("LibraryWebAPI.Model.Users", b =>
                {
                    b.Navigation("IssueBooks");

                    b.Navigation("ReturnBook");
                });
#pragma warning restore 612, 618
        }
    }
}
