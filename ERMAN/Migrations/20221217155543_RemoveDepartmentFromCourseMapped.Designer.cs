﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ERMAN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    [DbContext(typeof(ErmanDbContext))]
    [Migration("20221217155543_RemoveDepartmentFromCourseMapped")]
    partial class RemoveDepartmentFromCourseMapped
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ERMAN.Models.Authentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationTable");
                });

            modelBuilder.Entity("ERMAN.Models.Checklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool[]>("Checked")
                        .IsRequired()
                        .HasColumnType("boolean[]");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ChecklistTable");
                });

            modelBuilder.Entity("ERMAN.Models.Coordinator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthId")
                        .HasColumnType("integer");

                    b.Property<int?>("CoordinatorUniversityId")
                        .HasColumnType("integer");

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Faculty")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CoordinatorTable");
                });

            modelBuilder.Entity("ERMAN.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AInstructorId")
                        .HasColumnType("integer");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("CourseCredit")
                        .HasColumnType("real");

                    b.Property<int?>("CourseMappedId")
                        .HasColumnType("integer");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CourseType")
                        .HasColumnType("text");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsElectiveCourse")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsForeignUniversity")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMustCourse")
                        .HasColumnType("boolean");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("UniversityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseMappedId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ERMAN.Models.CourseMapped", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApprovedStatus")
                        .HasColumnType("integer");

                    b.Property<int>("BilkentCourseId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BilkentCourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseMappedTable");
                });

            modelBuilder.Entity("ERMAN.Models.FAQItem", b =>
                {
                    b.Property<int>("FAQItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FAQItemId"));

                    b.Property<string>("FAQAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FAQQuestion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FAQItemId");

                    b.ToTable("FAQTable");
                });

            modelBuilder.Entity("ERMAN.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("InstructorEmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("integer");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InstructorTable");
                });

            modelBuilder.Entity("ERMAN.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoordinatorId")
                        .HasColumnType("integer");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("messageText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("receiverId")
                        .HasColumnType("integer");

                    b.Property<int>("senderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("MessageTable");
                });

            modelBuilder.Entity("ERMAN.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NotificationTable");
                });

            modelBuilder.Entity("ERMAN.Models.PlacementStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("DurationPreferred")
                        .HasColumnType("text");

                    b.Property<string>("Faculty")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<List<string>>("PreferredUniversity")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int?>("Ranking")
                        .HasColumnType("integer");

                    b.Property<string>("StudentId")
                        .HasColumnType("text");

                    b.Property<string>("TotalPoints")
                        .HasColumnType("text");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PlacementStudentTable");
                });

            modelBuilder.Entity("ERMAN.Models.ProposalCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthId")
                        .HasColumnType("integer");

                    b.Property<int?>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Intensions")
                        .HasColumnType("text");

                    b.Property<string>("StudentId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("ProposalCourseTable");
                });

            modelBuilder.Entity("ERMAN.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationStatus")
                        .HasColumnType("text");

                    b.Property<int>("AuthId")
                        .HasColumnType("integer");

                    b.Property<int?>("CoordinatorId")
                        .HasColumnType("integer");

                    b.Property<string>("CoordinatorName")
                        .HasColumnType("text");

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("DurationPreffered")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(360)
                        .HasColumnType("character varying(360)");

                    b.Property<string>("Faculty")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int?>("Program")
                        .HasColumnType("integer");

                    b.Property<int>("Ranking")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPoints")
                        .HasColumnType("double precision");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("StudentTable");
                });

            modelBuilder.Entity("ERMAN.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<string>("DueDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("ERMAN.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("UniversityCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("UniversityTable");
                });

            modelBuilder.Entity("ERMAN.Models.Course", b =>
                {
                    b.HasOne("ERMAN.Models.CourseMapped", null)
                        .WithMany("HostCourses")
                        .HasForeignKey("CourseMappedId");

                    b.HasOne("ERMAN.Models.Instructor", null)
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId");

                    b.HasOne("ERMAN.Models.Student", null)
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ERMAN.Models.CourseMapped", b =>
                {
                    b.HasOne("ERMAN.Models.Course", "BilkentCourse")
                        .WithMany()
                        .HasForeignKey("BilkentCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERMAN.Models.Student", null)
                        .WithMany("SelectedCourses")
                        .HasForeignKey("StudentId");

                    b.Navigation("BilkentCourse");
                });

            modelBuilder.Entity("ERMAN.Models.Message", b =>
                {
                    b.HasOne("ERMAN.Models.Coordinator", null)
                        .WithMany("Messages")
                        .HasForeignKey("CoordinatorId");

                    b.HasOne("ERMAN.Models.Instructor", null)
                        .WithMany("Messages")
                        .HasForeignKey("InstructorId");

                    b.HasOne("ERMAN.Models.Student", null)
                        .WithMany("Messages")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ERMAN.Models.ProposalCourse", b =>
                {
                    b.HasOne("ERMAN.Models.CourseMapped", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ERMAN.Models.Student", b =>
                {
                    b.HasOne("ERMAN.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId");

                    b.Navigation("University");
                });

            modelBuilder.Entity("ERMAN.Models.University", b =>
                {
                    b.HasOne("ERMAN.Models.Student", null)
                        .WithMany("UniversityPreference")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ERMAN.Models.Coordinator", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ERMAN.Models.CourseMapped", b =>
                {
                    b.Navigation("HostCourses");
                });

            modelBuilder.Entity("ERMAN.Models.Instructor", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ERMAN.Models.Student", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Messages");

                    b.Navigation("SelectedCourses");

                    b.Navigation("UniversityPreference");
                });
#pragma warning restore 612, 618
        }
    }
}
