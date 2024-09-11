﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolNotes.API.Database;

#nullable disable

namespace SchoolNotes.API.Migrations
{
    [DbContext(typeof(DBPostgreSQL))]
    partial class DBPostgreSQLModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SchoolNotes.API.Models.Course", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.CourseSession", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("CourseSession");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.CourseSessionStudents", b =>
                {
                    b.Property<Guid>("CourseSessionID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uuid");

                    b.HasKey("CourseSessionID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("CourseSessionStudents");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.Score", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseSessionID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CourseSessionID", "StudentID");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.Student", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.CourseSession", b =>
                {
                    b.HasOne("SchoolNotes.API.Models.Course", "Course")
                        .WithMany("CourseSessions")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.CourseSessionStudents", b =>
                {
                    b.HasOne("SchoolNotes.API.Models.CourseSession", "CourseSession")
                        .WithMany("CourseSessionStudents")
                        .HasForeignKey("CourseSessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolNotes.API.Models.Student", "Student")
                        .WithMany("CourseSessionStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSession");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.Score", b =>
                {
                    b.HasOne("SchoolNotes.API.Models.CourseSessionStudents", "CourseSessionStudent")
                        .WithMany("Scores")
                        .HasForeignKey("CourseSessionID", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSessionStudent");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.Course", b =>
                {
                    b.Navigation("CourseSessions");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.CourseSession", b =>
                {
                    b.Navigation("CourseSessionStudents");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.CourseSessionStudents", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("SchoolNotes.API.Models.Student", b =>
                {
                    b.Navigation("CourseSessionStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
