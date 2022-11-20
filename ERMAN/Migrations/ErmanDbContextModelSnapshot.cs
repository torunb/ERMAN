﻿// <auto-generated />
using System;
using ERMAN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    [DbContext(typeof(ErmanDbContext))]
    partial class ErmanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

<<<<<<< Updated upstream
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
=======
            modelBuilder.Entity("ERMAN.Models.Coordinator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CoordinatorEmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CoordinatorId")
                        .HasColumnType("integer");

                    b.Property<string>("CoordinatorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("CoordinatorTable");
                });

            modelBuilder.Entity("ERMAN.Models.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FaqTable");
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

                    b.Property<int>("InstructorId")
                        .HasColumnType("integer");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InstructorTable");
>>>>>>> Stashed changes
                });

            modelBuilder.Entity("ERMAN.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("boolean");

                    b.Property<string>("StudentEmailAddress")
                        .IsRequired()
                        .HasMaxLength(360)
                        .HasColumnType("character varying(360)");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("StudentTable");
                });

<<<<<<< HEAD
<<<<<<< Updated upstream
            modelBuilder.Entity("ERMAN.Models.StudentPlacement", b =>
                {
                    b.Property<int>("PlacementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlacementId"));

                    b.Property<string>("DurationPrefered")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Eng101")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Eng102")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("ErasmusApplicationWithGradesBehindSeUe")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsInWaitingList")
                        .HasColumnType("boolean");

                    b.Property<double>("LanguagePoints")
                        .HasColumnType("double precision");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("TotalPoints")
                        .HasColumnType("double precision");

                    b.Property<double>("TranscriptGradeContribution")
                        .HasColumnType("double precision");

                    b.Property<double>("TranscriptGradeFromFour")
                        .HasColumnType("double precision");

                    b.Property<double>("TranscriptGradeFromHundred")
                        .HasColumnType("double precision");

                    b.Property<double>("TranscriptPoints")
                        .HasColumnType("double precision");

                    b.Property<double>("UECGPA")
                        .HasColumnType("double precision");

                    b.Property<int>("UESECount")
                        .HasColumnType("integer");

                    b.Property<string[]>("UniversityChoices")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("PlacementId");

                    b.ToTable("StudentPlacements");
=======
            modelBuilder.Entity("ERMAN.Models.Todo", b =>
=======
            modelBuilder.Entity("ERMAN.Models.StudentUser", b =>
>>>>>>> yarkin
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

<<<<<<< HEAD
                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<string>("DueDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Starred")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TodoTable");
                });

            modelBuilder.Entity("ERMAN.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UniversityCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UniversityTable");
>>>>>>> Stashed changes
=======
                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentUserTable");
                });

            modelBuilder.Entity("ERMAN.Models.StudentUser", b =>
                {
                    b.HasOne("ERMAN.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
>>>>>>> yarkin
                });
#pragma warning restore 612, 618
        }
    }
}
