﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolDBContext))]
    partial class SchoolDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SchoolSystem.Core.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("courseid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int?>("CourseStatusId")
                        .HasColumnName("coursestatusid")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("CourseId")
                        .HasName("tb_course_pkey");

                    b.HasIndex("CourseStatusId");

                    b.ToTable("tb_course");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.CourseGradebook", b =>
                {
                    b.Property<int>("CourseGradebookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("coursegradebookid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<decimal?>("Average")
                        .HasColumnName("average")
                        .HasColumnType("numeric(3,2)");

                    b.Property<int?>("CourseId")
                        .HasColumnName("courseid")
                        .HasColumnType("integer");

                    b.Property<decimal>("Q1")
                        .HasColumnName("q1")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("Q2")
                        .HasColumnName("q2")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("Q3")
                        .HasColumnName("q3")
                        .HasColumnType("numeric(3,2)");

                    b.Property<bool>("Status")
                        .HasColumnName("status")
                        .HasColumnType("boolean");

                    b.Property<int?>("StudentId")
                        .HasColumnName("studentid")
                        .HasColumnType("integer");

                    b.Property<int?>("TeacherId")
                        .HasColumnName("teacherid")
                        .HasColumnType("integer");

                    b.HasKey("CourseGradebookId")
                        .HasName("tb_course_gradebook_pkey");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("tb_course_gradebook");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.CourseStatus", b =>
                {
                    b.Property<int>("CourseStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("coursestatusid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("CourseStatusId")
                        .HasName("tb_course_status_pkey");

                    b.ToTable("tb_course_status");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rolid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("RolId")
                        .HasName("tb_rol_pkey");

                    b.ToTable("tb_rol");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("studentid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Classroom")
                        .IsRequired()
                        .HasColumnName("classroom")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int?>("UserId")
                        .HasColumnName("userid")
                        .HasColumnType("integer");

                    b.HasKey("StudentId")
                        .HasName("tb_student_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("tb_student");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("teacherid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Subject")
                        .HasColumnName("subject")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int?>("UserId")
                        .HasColumnName("userid")
                        .HasColumnType("integer");

                    b.HasKey("TeacherId")
                        .HasName("tb_teacher_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("tb_teacher");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int>("Nid")
                        .HasColumnName("nid")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("passsword")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int?>("RolId")
                        .HasColumnName("rolid")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("UserId")
                        .HasName("tb_user_pkey");

                    b.HasIndex("RolId");

                    b.HasIndex("Nid", "Username")
                        .IsUnique()
                        .HasName("tb_user_nid_username_key");

                    b.ToTable("tb_user");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.Course", b =>
                {
                    b.HasOne("SchoolSystem.Core.Entities.CourseStatus", "CourseStatus")
                        .WithMany("Courses")
                        .HasForeignKey("CourseStatusId")
                        .HasConstraintName("tb_course_coursestatusid_fkey");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.CourseGradebook", b =>
                {
                    b.HasOne("SchoolSystem.Core.Entities.Course", "Course")
                        .WithMany("CourseGradebooks")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("tb_course_gradebook_courseid_fkey");

                    b.HasOne("SchoolSystem.Core.Entities.Student", "Student")
                        .WithMany("CourseGradebooks")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("tb_course_gradebook_studentid_fkey");

                    b.HasOne("SchoolSystem.Core.Entities.Teacher", "Teacher")
                        .WithMany("CourseGradebooks")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("tb_course_gradebook_teacherid_fkey");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.Student", b =>
                {
                    b.HasOne("SchoolSystem.Core.Entities.User", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .HasConstraintName("tb_student_userid_fkey");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.Teacher", b =>
                {
                    b.HasOne("SchoolSystem.Core.Entities.User", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("tb_teacher_userid_fkey");
                });

            modelBuilder.Entity("SchoolSystem.Core.Entities.User", b =>
                {
                    b.HasOne("SchoolSystem.Core.Entities.Rol", "Rol")
                        .WithMany("Users")
                        .HasForeignKey("RolId")
                        .HasConstraintName("tb_user_rolid_fkey");
                });
#pragma warning restore 612, 618
        }
    }
}
