﻿// <auto-generated />
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

            modelBuilder.Entity("ERMAN.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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
#pragma warning restore 612, 618
        }
    }
}
