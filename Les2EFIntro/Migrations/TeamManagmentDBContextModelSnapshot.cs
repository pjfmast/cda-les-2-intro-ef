﻿// <auto-generated />
using System;
using Les2EFIntro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Les2EFIntro.Migrations
{
    [DbContext(typeof(TeamManagmentDBContext))]
    partial class TeamManagmentDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Les2EFIntro.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Email = "henk@breda.nl",
                            Name = "Henk",
                            TeamId = 201
                        },
                        new
                        {
                            Id = 1002,
                            Email = "loes@avans.nl",
                            Name = "Loes",
                            TeamId = 201
                        });
                });

            modelBuilder.Entity("Les2EFIntro.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 201,
                            Group = "Groep-1",
                            Title = "You snooze, you loose!"
                        },
                        new
                        {
                            Id = 202,
                            Group = "Groep-2",
                            Title = "Nachos"
                        },
                        new
                        {
                            Id = 203,
                            Group = "Groep-3",
                            Title = "3 front-end devs + 1 back-end dev"
                        },
                        new
                        {
                            Id = 204,
                            Group = "Groep-4",
                            Title = "Cinavas"
                        });
                });

            modelBuilder.Entity("Les2EFIntro.Models.Member", b =>
                {
                    b.HasOne("Les2EFIntro.Models.Team", "Team")
                        .WithMany("Enrolled")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Les2EFIntro.Models.Team", b =>
                {
                    b.Navigation("Enrolled");
                });
#pragma warning restore 612, 618
        }
    }
}
